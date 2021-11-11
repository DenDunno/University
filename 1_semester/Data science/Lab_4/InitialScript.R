cat("\014")  

library(RColorBrewer)
library(ggplot2)
library(dplyr)
library(MASS)
library(effsize)

setwd("D:/Business/Study/Univ/3_course/1_semester/Data science/Lab_4/")
options(scipen = 999)

diamonds = read.csv(file = 'diamonds_dataset.csv', header = TRUE)

diamonds$Category = as.factor(diamonds$shape)
diamonds = group_by(diamonds, diamonds$shape)