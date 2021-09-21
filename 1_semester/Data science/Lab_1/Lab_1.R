cat("\014") 

#1. Arithmetic mean, median

mean(x)
median(x)


#2. Variance, standard deviation,  coefficient of variation , range of variation, interquartile range

var(x)
sd(x)
sd(x) / mean(x)
max(x) - min(x)
IQR(x)


#3. Box plot

boxplot(x , xlab = "Курс гривні"
          , main = "Курс гривні до долара за 20.09.2020 - 20.09.2021"
          , col = "coral"
          , horizontal = TRUE)
        
        
#4. Extreme points , quartiles

quantile(x)


#5. 1 and 9th decile

quantile(x, probs = seq(.1, .9, by = .1))[1]
quantile(x, probs = seq(.1, .9, by = .1))[9]


#6. Skewness , kurtosis

skewness(x, na.rm = TRUE)
kurtosis(x, na.rm = TRUE)


#7. Build histogram with Sturges' , Scott , FD rule. Build hypothetical density function

# Sturges' rule
hist.default(x , prob = T , right = F
           , xlab = "Курс гривні"
           , ylab = "Щільність" 
           , main ="Курс гривні до долара за 20.09.2020 - 20.09.2021 (базове правило)"
           , col ="lightblue")

#Scott's rule
hist.scott(x , prob = T , right = F
           , xlab = "Курс гривні"
           , ylab = "Щільність" 
           , main ="Курс гривні до долара за 20.09.2020 - 20.09.2021 (правило Скотта)"
           , col ="lightgreen")

#Freedman-Diaconis rule
hist.FD(x , prob = T , right = F
           , xlab = "Курс гривні"
           , ylab = "Щільність" 
           , main ="Курс гривні до долара за 20.09.2020 - 20.09.2021 (правило Фрідмана-Діаконіса)"
           , col ="gold")

curve(dnorm(x, mean=mean(x), sd=sd(x)), col="blue", lwd=2, add=T, yaxt="n")

#8. Q-Q diagram

qqnorm(x, xlab="Теоретичні квантилі", ylab="Вибіркові квантилі" , main = 'Q-Q діаграма')
qqline(x, col="red" , lwd = 3)


#9. P-P diagram

plot(pnorm(sort(x), mean(x), sd(x))
     , (1:length(x))/length(x) 
     ,xlab="Теоретичні квантилі"
     , ylab="Емпірична функція розподілу" 
     , main = 'P-P діаграма')

abline(0, 1, col="red")
