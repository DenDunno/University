cat("\014") 

setwd("D:/Business/Study/Univ/3_course/1_semester/Data science/Lab_1/")
library(readxl)
ExchangeRate_UAH =  read_excel("ExchangeRate_UAH.xlsx", 
                               col_types = c("text", "skip", "skip", 
                                             "text", "skip", "text", "numeric"))

DollarExchangeRate = ExchangeRate_UAH[ExchangeRate_UAH$`Код літерний` == 'USD',]
EuroExchangeRate = ExchangeRate_UAH[ExchangeRate_UAH$`Код літерний` == 'EUR',]


ExchangeRate_UAH$Дата = as.Date(ExchangeRate_UAH$Дата , "%d.%m.%Y")
DollarExchangeRate$Дата = as.Date(DollarExchangeRate$Дата , "%d.%m.%Y")
EuroExchangeRate$Дата = as.Date(EuroExchangeRate$Дата , "%d.%m.%Y")


plot(DollarExchangeRate$Дата , DollarExchangeRate$`Офіційний курс гривні, грн` , type = 'l' , col='red' , lwd = 2 , xlab = 'Дата' , ylab = 'Курс долара' , main = 'Курс гривні до долара')
plot(sort(DollarExchangeRate$`Офіційний курс гривні, грн`) , type = 'l' , col='red' , lwd = 2)



