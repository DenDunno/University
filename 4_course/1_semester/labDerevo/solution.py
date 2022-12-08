from os import stat
from Pyro4 import expose

class Solver:
    def __init__(self, workers=None, input_file_name=None, output_file_name=None):
        self.input_file_name = input_file_name
        self.output_file_name = output_file_name
        self.workers = workers

    def solve(self):
        strings = self.read_input()
        n = len(strings)
        step = n / len(self.workers)

        mapped = []
        for i in xrange(0, len(self.workers)):
            mapped.append(self.workers[i].mymap(i*step, (i+1)*step, strings))

        reduced = self.myreduce(mapped)
        self.write_output(reduced)

    @staticmethod
    @expose
    def mymap(a, b, strings):
        print(a, b)
        
        res = []
        for i in xrange(a, b):
            if strings[i] == strings[i][::-1]:
                res.append(strings[i])
        
        return res

    @staticmethod
    @expose
    def myreduce(mapped):
        res = []
        for chunk in mapped:
            for s in chunk.value:
                res.append(s)
        
        return res

    def read_input(self):
        f = open(self.input_file_name, 'r')
        return [line.strip() for line in f.readlines()]

    def write_output(self, output):
        f = open(self.output_file_name, 'w')

        for s in output:
            f.write(s + '\n')

        f.close()