cat("\014")  

library(RColorBrewer)
library(ggplot2)
library(dplyr)
library(MASS)
library(effsize)
library(dplyr)
library(factoextra)
library(stats)
library(ggfortify)
library(fossil)

setwd("D:/Business/Study/Univ/3_course/1_semester/Data science/Lab_6/")

menu = read.csv(file = 'menu.csv', header = TRUE)
menu = head(menu,50)
menu = data.frame(Category = menu$Category , Name = menu$Item, Calories = menu$Calories , Cholesterol = menu$Cholesterol)

row.names(menu) = menu$Name