import random

import numpy as np

m = 2
expected = np.array([[m, 2 * m], [4 * m, m]])

covarition_matrices = np.array([
    [
        [0.7 * m, m * 0.01],
        [m * 0.01, 0.7 * m]
    ],
    [
        [1 + m * 0.01, -m * 0.01],
        [-m * 0.01, 1 + m * 0.01]
    ]
])

apriori_probability_1 = 1 / 3

count_1 = 0
count_2 = 0


for i in range(100):
    random_value = random.uniform(0, 1)

    if random_value > apriori_probability_1:
        count_2 += 1
    else:
        count_1 += 1

blob_1 = np.random.multivariate_normal(mean=expected[0], cov=covarition_matrices[0], size=count_1)
blob_2 = np.random.multivariate_normal(mean=expected[1], cov=covarition_matrices[1], size=count_2)

blob_sum = np.concatenate((blob_1, blob_2))