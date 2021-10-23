cat("\014")  

#install.packages('corrplot')
#install.packages("GGally")
#install.packages("lme4")
library(corrplot)
library(GGally)
library(lme4)

setwd("D:/Business/Study/Univ/3_course/1_semester/Data science/Lab_3/")

weaterHistory = read.csv(file = 'weatherHistory.csv', header = TRUE)
weaterHistory = weaterHistory[-c(10)]
weaterHistory = weaterHistory[-c(1:80000), ]

data = weaterHistory[ , c(4 : 9)]
data = data[-c(5)]

names(data)[1] = 'Реальна температура'
names(data)[2] = 'Уявна температура'
names(data)[3] = 'Вологість'
names(data)[4] = 'Швидкість вітру'
names(data)[5] = 'Видимість'

x = data$`Реальна температура`
y = data$Вологість
