#!/usr/bin/python

import timeit, sys, io

def wrapper(func, *args, **kwargs):
    def wrapped():
        return func(*args, **kwargs)
    return wrapped

def start(file, outfile):
    #input = open(file, 'r')
    #output = open(outfile, 'w')

    line = input.readline()
    while line:
        line = line.replace('Tellus', 'Terra')
        line = line.replace('tellus', 'terra')
        output.write(line)
        line = input.readline()

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

    #ns = time.time()
    wrapped = wrapper(start, file, output)
    print (timeit.timeit(wrapped, number=1)*1000)
    #totaltime = (time.time() - ns) / 1000000
    #print (totaltime)
    sys.exit(0)

if __name__ == '__main__':main(sys.argv[1:])
