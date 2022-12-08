from os import stat
from Pyro4 import expose
import random


class Point:
    def __init__(self, x, y):
        self.x = x
        self.y = y


class BoundingBox:
    def __init__(self, x_max, y_max, x_min, y_min):
        self.Max = Point(x_max, y_max)
        self.Min = Point(x_min, y_min)

    def square(self):
        return (self.Max.x - self.Min.x) * (self.Max.y - self.Min.y)


def evaluate_bounding_box(points):
    x_min = 1000.0
    x_max = -1000.0
    y_min = 1000.0
    y_max = -1000.0

    for point in points:
        if point.x < x_min:
            x_min = point.x
        if point.x > x_max:
            x_max = point.x
        if point.y < y_min:
            y_min = point.y
        if point.y > y_max:
            y_max = point.y

    return BoundingBox(x_max, y_max, x_min, y_min)


def get_throw_point(box):
    return Point(random.uniform(box.Min.x, box.Max.x), random.uniform(box.Min.y, box.Max.y))


def sign(p1, p2, p3):
    return (p1.x - p3.x) * (p2.y - p3.y) - (p2.x - p3.x) * (p1.y - p3.y)


def point_inside_triangle(pt, points):
    v1 = points[0]
    v2 = points[1]
    v3 = points[2]

    d1 = sign(pt, v1, v2)
    d2 = sign(pt, v2, v3)
    d3 = sign(pt, v3, v1)

    has_neg = (d1 < 0) or (d2 < 0) or (d3 < 0)
    has_pos = (d1 > 0) or (d2 > 0) or (d3 > 0)

    return not (has_neg and has_pos)


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
            mapped.append(self.workers[i].mymap(i * step, (i + 1) * step, strings))

        reduced = self.myreduce(mapped)
        self.write_output(reduced)

    @staticmethod
    @expose
    def mymap(a, b, strings):
        res = []
        triangles = []
        for i in xrange(a, b):
            floats = []

            for floatString in strings[i].split(' '):
                floats.append(float(floatString))

            triangles.append(floats)

        for triangle in triangles:

            points = [Point(triangle[0], triangle[1]),
                      Point(triangle[2], triangle[3]),
                      Point(triangle[4], triangle[5])]

            boundingBox = evaluate_bounding_box(points)

            thrownPoints = 0
            thrownPointsInsideTriangle = 0

            for _ in range(1000):
                throwPoint = get_throw_point(boundingBox)

                if point_inside_triangle(throwPoint, points):
                    thrownPointsInsideTriangle += 1

                thrownPoints += 1

            res.append(str(boundingBox.square() * thrownPointsInsideTriangle / thrownPoints))
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
