#!/usr/bin/python3
# -*- coding: utf-8 -*-

import sys, io
from PyQt5.QtCore import *
from PyQt5.QtWidgets import *
from PyQt5.QtGui import *

class Mywindow(QWidget):
    def __init__(self):
        super().__init__()
        self.initUI()

    def createList(self):
        lst = QListView()
        model = QStandardItemModel(lst)

        for line in fileLines:
            item = QStandardItem(line)
            item.setText(str(line))
            item.setCheckable(False)
            model.appendRow(item)

        lst.setModel(model)

        return lst

    def initUI(self):
        self.setGeometry(300,300,300,200)
        self.setWindowTitle("Test-GrafList")

        layout = QVBoxLayout()
        self.setLayout(layout)
        layout.addWidget(self.createList())

        self.show()

def readFile(file):
    global fileLines
    inp = open(file, 'r')
    line = inp.read()
    fileLines = line.splitlines()

def main(argv):
    global app
    readFile(argv[0])
    app = QApplication(sys.argv)
    w = Mywindow()
    #sys.exit(app.exec_())
    sys.exit(0)

if __name__ == '__main__':main(sys.argv[1:])
