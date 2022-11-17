

library(psych) 
library(moments)

setwd("D:/Business/University/University_3_course/4_course/1_semester/Data science/Lab_1")
data = read.table("A2.txt", header = FALSE, sep = ",", dec = ".")
data = as.data.frame.matrix(data)


getmode = function(x) 
{
  uniqv = unique(x)
  uniqv[which.max(tabulate(match(x, uniqv)))]
}

GiniMd = function(x, na.rm=FALSE) {
  if(na.rm) {
    k = is.na(x)
    if(any(k)) x <- x[! k]
  }
  n =length(x)
  if(n < 2) return(NA)
  w = 4 * ((1 : n) - (n - 1) / 2) / n / (n - 1)
  sum(w * sort(x - mean(x)))  ## center for numerical stability only
}

preliminaryProcessing = function(x, channelIndex)
{
  print(paste(channelIndex, " канал"))
  print(paste("Середнє = ", mean(x)))
  print(paste("Середнє гармонійне = ", harmonic.mean(x)))
  print(paste("Середнє геометричне = ", geometric.mean(x)))
  print(paste("Дисперсія = ", var(x)))
  print(paste("Середня різниця Джині = ", GiniMd(x, na.rm=FALSE)))
  print(paste("Мода = ", getmode(x)))
  print(paste("Медіана = ", median(x)))
  print(paste("Коефіцієнт асиметрії = ", skewness(x)))
  print(paste("Коефіцієнт ексцесу = ", kurtosis(x)))
  
  
  hist(x, main = paste(channelIndex, " канал"), xlab="Value", col="deepskyblue")
  
  print("Тест:")
  shapiro.test(x)
}
