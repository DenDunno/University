cat("\014")  

#install.packages('corrplot')
#install.packages("GGally")
library(corrplot)
library(GGally)

setwd("D:/Business/Study/Univ/3_course/1_semester/Data science/Lab_3/")

weaterHistory = read.csv(file = 'weatherHistory.csv', header = TRUE)
weaterHistory = weaterHistory[-c(10)]
weaterHistory = weaterHistory[-c(1:80000), ]

x = weaterHistory[ , c(4 : 9)]
x = x[-c(5)]

names(x)[1] = 'Реальна температура'
names(x)[2] = 'Уявна температура'
names(x)[3] = 'Вологість'
names(x)[4] = 'Швидкість вітру'
names(x)[5] = 'Видимість'


my_cols <- c("#00AFBB", "#E7B800", "#FC4E07")  