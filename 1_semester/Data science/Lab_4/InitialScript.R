cat("\014")  

library(ggplot2)
library(dplyr)

setwd("D:/Business/Study/Univ/3_course/1_semester/Data science/Lab_4/")

googlePlayStore = read.csv(file = 'googleplaystore.csv', header = TRUE)

googlePlayStore$Category = as.factor(googlePlayStore$Category)
googlePlayStore = group_by(googlePlayStore, googlePlayStore$Category)

installs = googlePlayStore$Installs
genres = googlePlayStore$Category

as = googlePlayStore$Installs[substr(name,1,nchar(name)-1)]