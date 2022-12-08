import random

strings = []

for _ in range(1000):

    points = []
    for point in range(6):
        points.append(round(random.uniform(0, 100), 2))

    strings.append(" ".join([str(i) for i in points]))

with open('points.txt', 'w') as f:
    for s in strings:
        f.write(s + '\n')