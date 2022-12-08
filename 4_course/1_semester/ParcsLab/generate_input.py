import string, random

strings = []
for _ in range(2900000):
    is_palindrome = bool(random.choice([0, 1]))
    s = ''.join(random.choices(string.ascii_letters, k=random.randint(1,10)))

    if is_palindrome:
        s += s[::-1]
    
    strings.append(s)

with open('input29.txt', 'w') as f:
    for s in strings:
        f.write(s + '\n')