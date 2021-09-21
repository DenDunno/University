cat("\014") 

setwd("D:/Business/Study/Univ/3_course/1_semester/Data science/Lab_1/")
library(readxl)
ExchangeRate_UAH =  read_excel("ExchangeRate_UAH.xlsx", 
                               col_types = c("text", "skip", "skip", 
                                             "text", "skip", "text", "numeric"))

DollarExchangeRate = ExchangeRate_UAH[ExchangeRate_UAH$`Код літерний` == 'USD',]
EuroExchangeRate = ExchangeRate_UAH[ExchangeRate_UAH$`Код літерний` == 'EUR',]

x = DollarExchangeRate$`Офіційний курс гривні, грн`

ExchangeRate_UAH$Дата = as.Date(ExchangeRate_UAH$Дата , "%d.%m.%Y")
DollarExchangeRate$Дата = as.Date(DollarExchangeRate$Дата , "%d.%m.%Y")
EuroExchangeRate$Дата = as.Date(EuroExchangeRate$Дата , "%d.%m.%Y")

#install.packages("moments")

library(moments)
library(MASS)
