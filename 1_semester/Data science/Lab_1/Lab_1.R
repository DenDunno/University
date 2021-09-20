cat("\014") 

#1. Arithmetic mean, median

mean(DollarExchangeRate$`Офіційний курс гривні, грн`)
median(DollarExchangeRate$`Офіційний курс гривні, грн`)


#2. Variance, standard deviation,  coefficient of variation , range of variation, interquartile range

var(DollarExchangeRate$`Офіційний курс гривні, грн`)
sd(DollarExchangeRate$`Офіційний курс гривні, грн`)
sd(DollarExchangeRate$`Офіційний курс гривні, грн`) / mean(DollarExchangeRate$`Офіційний курс гривні, грн`)
max(DollarExchangeRate$`Офіційний курс гривні, грн`) - min(DollarExchangeRate$`Офіційний курс гривні, грн`)
IQR(DollarExchangeRate$`Офіційний курс гривні, грн`)


#3. Box plot

boxplot(ExchangeRate_UAH$Дата, грн ~ ExchangeRate_UAH$`Офіційний курс гривні, грн` , data = ExchangeRate_UAH )
