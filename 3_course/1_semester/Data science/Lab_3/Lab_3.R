# 1. Scatterplot
plot(x, y,
     main="Діаграма розсіювання",
     xlab="Реальна температура",
     ylab="Вологість",
     col = 'lightgreen',
     pch = 20,
     cex = 1,
     lwd = 6)


# 2. Regression model
regressionModel = lm(y ~ x)
summary(regressionModel)
1-mean((resid(regressionModel))^2)/mean((y-mean(y))^2)  # determination coefficient

slope =  sum((x - mean(x)) * (y - mean(y))) / sum((x-mean(x))^2)
intercept = mean(y)- slope * mean(x)


# 3. Regression line
abline(b = slope, a = intercept, lwd = 2, col = 'red')


# 4. Response-prediction plot
resid = resid(regressionModel)
prediction = y - resid
plot(prediction, y, 
     xlab="Прогнозовані значення",
     ylab="Значення відгуку", 
     main="Діаграма прогноз-відгук",
     pch = 20,
     col='lightblue',
     lwd = 6)
abline(0,1, col="red", lwd=2)


# 5. Residuals vs prediction plot 
plot(prediction, resid, 
     xlab="Прогнозовані значення", 
     ylab="Залишки", 
     main="Діаграма прогноз-залишки",
     pch = 20,
     col='pink',
     lwd = 6)
abline(0,0,lwd=2 , col='red')


# 6. Q-Q diagram
plot(regressionModel)
