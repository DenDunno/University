plot(DollarExchangeRate$Дата, DollarExchangeRate$`Офіційний курс гривні, грн`,
     type='l',
     lwd = 2 , 
     col="red",
     xlab = "Дата",
     ylab="Курс гривні",
     main = "Курс гривні до долара за 5.12.2020 - 5.12.2021")


sma(x, order=3, silent=F)
sma(x, order=5, silent=F)
sma(x, order=7, silent=F)


dollarTimeSeries = ts(x, DollarExchangeRate$Дата, frequency=12)
diff_1 = diff(dollarTimeSeries , lag = 12)
diff_2 = diff(diff_1)


plot(decompose(dollarTimeSeries))

plot(diff_1,
     type='l',
     lwd = 2 , 
     col="red",
     xlab = "Дата",
     ylab="Курс гривні",
     main = "1 диференціювання")

plot(diff_2,
     type='l',
     lwd = 2 , 
     col="red",
     xlab = "Дата",
     ylab="Курс гривні",
     main = "2 диференціювання")


diff_2 %>% ggtsdisplay()


holtWinters = HoltWinters(dollarTimeSeries)
prediction = predict(holtWinters, 50, prediction.interval = F)
plot(holtWinters, prediction,
     xlab="Рік", 
     ylab="Курс гривні до долара за 5.12.2020 - 5.12.2021",
     main="Прогноз за методом Холта-Вінтерса для курсу долара")


dollarTimeSeries %>% Arima(order=c(0,1,1), seasonal=c(0,1,1)) %>% residuals() %>% ggtsdisplay()
dollarTimeSeries %>% Arima(order=c(0,1,2), seasonal=c(0,1,1)) %>% residuals() %>% ggtsdisplay()
dollarTimeSeries %>% Arima(order=c(0,1,3), seasonal=c(0,1,1)) %>% residuals() %>% ggtsdisplay()


fit = arima(dollarTimeSeries, order=c(0,1,3), seasonal=c(0,1,1))
arimaPrediction = predict(fit, n.ahead = 50)
ts.plot(dollarTimeSeries, arimaPrediction$pred, 
        lty = c(1,3), col=c(5,2),
        lwd = 3)


sarima(dollarTimeSeries,0,1,3,0,1,1,4)