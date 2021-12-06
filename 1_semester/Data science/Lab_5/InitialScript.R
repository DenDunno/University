cat("\014")  

library(graphics)
library(smooth)
library(fpp)
library(RColorBrewer)
library(ggplot2)
library(dplyr)
library(MASS)
library(effsize)
library(readxl)
library(forecast)
library(astsa)
require(tseries)
require(astsa)

setwd("D:/Business/Study/Univ/3_course/1_semester/Data science/Lab_5/")

ExchangeRate_UAH =  read_excel("ExchangeRate_UAH.xlsx", 
                               col_types = c("text", "skip", "skip", 
                                             "text", "skip", "text", "numeric"))

DollarExchangeRate = ExchangeRate_UAH[ExchangeRate_UAH$`Код літерний` == 'USD',]

x = DollarExchangeRate$`Офіційний курс гривні, грн`

ExchangeRate_UAH$Дата = as.Date(ExchangeRate_UAH$Дата , "%d.%m.%Y")
DollarExchangeRate$Дата = as.Date(DollarExchangeRate$Дата , "%d.%m.%Y")