

library(psych) 
library(moments)
library(magrittr)
library(dplyr)

setwd("D:/Business/University/University_3_course/4_course/1_semester/Data science/Lab_1")
data = read.table("A2.txt", header = FALSE, sep = ",", dec = ".")
data = as.data.frame.matrix(data)


getmode = function(x) 
{
  uniqv = unique(x)
  uniqv[which.max(tabulate(match(x, uniqv)))]
}

GiniMd = function(x, na.rm=FALSE) 
{
  if(na.rm) 
  {
    k = is.na(x)
    if(any(k)) x <- x[! k]
  }
  
  n =length(x)
  if(n < 2) return(NA)
  w = 4 * ((1 : n) - (n - 1) / 2) / n / (n - 1)
  sum(w * sort(x - mean(x)))  ## center for numerical stability only
}

DispersAnalasis <- function(values) 
{
  disan <- ((1 / (length(values) - 1)) * sum(((values - sum(values))*(values - sum(values)))))
  return(disan)
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

normalization = function(x)
{
  tempData = as.data.frame(scale(data)) 
  print(paste("Cереднє = ", mean(tempData$V1)))
  print(paste("Дисперсія = ", var(tempData$V1)))
}

anova = function(x)
{
  temp = data %>% summarise_each(funs(DispersAnalasis))
  max = max(temp)
  sum = sum(temp)
  g = max / sum
  
  print(paste("Max = ", max))
  print(paste("Sum = ", sum))
  print(paste("G = ", g))
  print(paste("ga(k, n) = ", 0.153))
}

twoWayAnova = function(x)
{
  data1 = data[1:1000, ] 
  data2 = data[1001:2000, ] 
  data3 = data[2001:3000, ] 
  data4 = data[3001:4000, ] 
  data5 = data[4001:5000, ] 
  
  mean1 = data1 %>% summarise_each(funs(mean))
  mean2 = data2 %>% summarise_each(funs(mean))
  mean3 = data3 %>% summarise_each(funs(mean))
  mean4 = data4 %>% summarise_each(funs(mean))
  mean5 = data5 %>% summarise_each(funs(mean))
  
  #print(mean1)
  #print(mean2)
  #print(mean3)
  #print(mean4)
  #print(mean5)
  
  sumByColumnTable = data.frame(mean1, mean2, mean3, mean4, mean5)
  sumByColumnTable.
}

fur = function(x)
{
  

}
