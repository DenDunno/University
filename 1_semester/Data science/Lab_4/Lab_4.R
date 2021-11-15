# 1. Linear scatterplot with mean

coul = brewer.pal(10, "Paired") 

stripchart(diamonds$price ~ diamonds$shape, 
           xlab = "Ціна в доларах за діамант", 
           ylab = "Форма діаманта",
           col=coul,
           pch=16,
           cex = 2)

tapply(diamonds$price, diamonds$shape, mean)

ggplot(diamonds, aes(x = diamonds$price)) + geom_histogram(bins=30) + facet_wrap(~ diamonds$shape, ncol = 1)
bartlett.test(diamonds$price ~ diamonds$shape, data = diamonds)

# 2.


model = lm(diamonds$price ~ diamonds$shape, data = diamonds)
anova(model)
summary(model)


kruskal.test(diamonds$price ~ diamonds$shape, diamonds)

model = aov(diamonds$price~diamonds$shape, data=diamonds)
TukeyHSD(model, conf.level=.95)
plot(TukeyHSD(model, conf.level=.95), las = 2 , cex.axis=0.5)


# 3.

contrasts(diamonds$shape)
contrasts(diamonds$shape)<-contr.sum(n=10)
contrasts(diamonds$shape)
model2<-lm(diamonds$price ~ diamonds$shape, data=diamonds)
summary(model2)
