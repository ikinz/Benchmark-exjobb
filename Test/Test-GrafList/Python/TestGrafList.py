#!/usr/bin/python3
# -*- coding: utf-8 -*-

import timeit, sys
from PyQt5.QtCore import *
from PyQt5.QtWidgets import *
from PyQt5.QtGui import *

def wrapper(func, *args, **kwargs):
    def wrapped():
        return func(*args, **kwargs)
    return wrapped

class Mywindow(QWidget):
    def __init__(self):
        super().__init__()
        self.initUI()
        
    def initUI(self):
        app = QApplication(sys.argv)
        
        self.setGeometry(300,300,300,200)
        self.setWindowTitle("Test")
        
        self.show()

def start(file, outfile):
    i = 0
    #ys.exit(app.exec_())
    

def main(argv):
    '''
    file = 'dump.txt'
    output = 'res.txt'
    for i in range(len(argv)):
        if argv[i] == '-f':
            i = i + 1
            file = argv[i]
        elif argv[i] == '-o':
            i = i + 1
            output = argv[i]
    
    wrapped = wrapper(start, file, output)
    print (timeit.timeit(wrapped, number=1)*1000)
    '''
    app = QApplication(sys.argv)
    w = Mywindow()
    sys.exit(app.exec_())
    #sys.exit(0)

if __name__ == '__main__':main(sys.argv[1:])
