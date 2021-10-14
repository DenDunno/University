# 1. Scatterplot

plot(x$`Реальна температура`, x$Вологість,
     main="Діаграма розсіювання",
     xlab="Реальна температура",
     ylab="Вологість",
     col = 'lightgreen',
     pch = 20,
     cex = 1)

abline(lm(x$Вологість ~ x$`Реальна температура`) , col ='red' , lwd = 2)

       