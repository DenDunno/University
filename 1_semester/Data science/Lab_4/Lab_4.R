# 1. Linear scatterplot with mean

coul = brewer.pal(10, "Paired") 

stripchart(diamonds$price ~ diamonds$shape, 
           xlab = "Ціна в доларах за діамант", 
           ylab = "Форма діаманта",
           col=coul,
           pch=16,
           cex = 2)

means = tapply(diamonds$price, diamonds$shape, mean)
abline(a = 0, b = mean(means), lty = 2, lwd = 5, col = 'red')

# 2.


model = lm(diamonds$price ~ diamonds$shape, data = diamonds)
anova(model)
summary(model)


kruskal.test(diamonds$price ~ diamonds$shape, diamonds)