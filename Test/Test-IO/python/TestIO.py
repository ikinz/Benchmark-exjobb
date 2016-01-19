#!/usr/bin/python

import timeit, sys, io

def wrapper(func, *args, **kwargs):
    def wrapped():
        return func(*args, **kwargs)
    return wrapped

def start(file, outfile):
    input = open(file, 'r')
    output = open(outfile, 'w')

    line = input.read()
    arr = line.splitlines()
    for i in range(len(arr)):
        arr[i] = arr[i].replace('Tellus', 'Terra')
        arr[i] = arr[i].replace('tellus', 'terra')
        output.write(arr[i] + "\n")

def main(argv):
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

    sys.exit(0)

if __name__ == '__main__':main(sys.argv[1:])
