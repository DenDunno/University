
# Data visualization
plot.ts(data["V1"], col="blue", lwd=2, main="1 канал")
plot.ts(data["V2"], col="blue", lwd=2, main="2 канал")
plot.ts(data["V3"], col="blue", lwd=2, main="3 канал")
plot.ts(data["V4"], col="blue", lwd=2, main="4 канал")
plot.ts(data["V5"], col="blue", lwd=2, main="5 канал")
plot.ts(data["V6"], col="blue", lwd=2, main="6 канал")
plot.ts(data["V7"], col="blue", lwd=2, main="7 канал")
plot.ts(data["V8"], col="blue", lwd=2, main="8 канал")
plot.ts(data["V9"], col="blue", lwd=2, main="9 канал")
plot.ts(data["V10"], col="blue", lwd=2, main="10 канал")
plot.ts(data["V11"], col="blue", lwd=2, main="11 канал")
plot.ts(data["V12"], col="blue", lwd=2, main="12 канал")


# Preliminary processing
preliminaryProcessing(data$V1, 1)
preliminaryProcessing(data$V2, 2)
preliminaryProcessing(data$V3, 3)
preliminaryProcessing(data$V4, 4)
preliminaryProcessing(data$V5, 5)
preliminaryProcessing(data$V6, 6)
preliminaryProcessing(data$V7, 7)
preliminaryProcessing(data$V8, 8)
preliminaryProcessing(data$V9, 9)
preliminaryProcessing(data$V10, 10)
preliminaryProcessing(data$V11, 11)
preliminaryProcessing(data$V12, 12)


# Normalization
normalization(data)


# ANOVA
anova(data)


# Two-way ANOVA
data1 = data[1:1000, ] 
data2 = data[1001:2000, ] 
data3 = data[2001:3000, ] 
data4 = data[3001:4000, ] 
data5 = data[4001:5000, ] 

mean1 = data1 %>% summarise_each(funs(mean))
mean2 = data2 %>% summarise_each(funs(mean))
mean3 = data3 %>% summarise_each(funs(mean))
mean4 = data4 %>% summarise_each(funs(mean))
mean5 = data5 %>% summarise_each(funs(mean))

print(mean1)
print(mean2)
print(mean3)
print(mean4)
print(mean5)

sumByColumnTable = rbind(mean1, mean2, mean3, mean4, mean5)
columnsSum = colSums(sumByColumnTable)
print(columnsSum)

sumMean1 = sum(mean1)
sumMean2 = sum(mean2)
sumMean3 = sum(mean3)
sumMean4 = sum(mean4)
sumMean5 = sum(mean5)

print(sumMean1)
print(sumMean2)
print(sumMean3)
print(sumMean4)
print(sumMean5)

Q1 = sum(mean1 * mean1) + 
     sum(mean2 * mean2) + 
     sum(mean3 * mean3) + 
     sum(mean4 * mean4) + 
     sum(mean5 * mean5)
     
Q22 <- function(values){
 x1 <- (sum(values * values))
 return (x1)
}
     
Q21 <- Q22(sumByColumnTable)
Q2 <- (1/5 * Q21)
print(Q2)


Q3 <- ((1 / 12) * (sum(mean1) * sum(mean1) + 
                   sum(mean2) * sum(mean2) +
                   sum(mean3) * sum(mean3) +
                   sum(mean4) * sum(mean4) +
                   sum(mean5) * sum(mean5)))
print(Q3)

Q4 <- ((1 / 60) * sum(sumByColumnTable) * sum(sumByColumnTable))
print(Q4)

S0_2 <- ((Q1 + Q4 - Q2 - Q3) / 44)
print(S0_2)

SA_2 <- ((Q2 - Q4) / 11)
print(SA_2)

SB_2 <- ((Q3 - Q4) / 4)
print(SB_2)

print(SA_2 / S0_2)
print(SB_2 / S0_2)
df(0.05, 11, 44)
df(0.05, 4, 44)


# Фур'є
furStat1 <- fft(data$V1)
furStat2 <- fft(data$V2)
furStat3 <- fft(data$V3)
furStat4 <- fft(data$V4)
furStat5 <- fft(data$V5)
furStat6 <- fft(data$V6)
furStat7 <- fft(data$V7)
furStat8 <- fft(data$V8)
furStat9 <- fft(data$V9)
furStat10 <- fft(data$V10)
furStat11 <- fft(data$V11)
furStat12 <- fft(data$V12)

invFurStat1 <- fft(furStat1)
invFurStat2 <- fft(furStat2)
invFurStat3 <- fft(furStat3)
invFurStat4 <- fft(furStat4)
invFurStat5 <- fft(furStat5)
invFurStat6 <- fft(furStat6)
invFurStat7 <- fft(furStat7)
invFurStat8 <- fft(furStat8)
invFurStat9 <- fft(furStat9)
invFurStat10 <- fft(furStat10)
invFurStat11 <- fft(furStat11)
invFurStat12 <- fft(furStat12)

spectrum(furStat1, type = "l", col="red")
spectrum(invFurStat1, type = "l", col="red")

spectrum(furStat2, type = "l", col="red")
spectrum(invFurStat2, type = "l", col="red")

spectrum(furStat3, type = "l", col="red")
spectrum(invFurStat3, type = "l", col="red")

spectrum(furStat4, type = "l", col="red")
spectrum(invFurStat4, type = "l", col="red")

spectrum(furStat5, type = "l", col="red")
spectrum(invFurStat5, type = "l", col="red")

spectrum(furStat6, type = "l", col="red")
spectrum(invFurStat6, type = "l", col="red")

spectrum(furStat7, type = "l", col="red")
spectrum(invFurStat7, type = "l", col="red")

spectrum(furStat8, type = "l", col="red")
spectrum(invFurStat8, type = "l", col="red")

spectrum(furStat9, type = "l", col="red")
spectrum(invFurStat9, type = "l", col="red")

spectrum(furStat10, type = "l", col="red")
spectrum(invFurStat10, type = "l", col="red")

spectrum(furStat11, type = "l", col="red")
spectrum(invFurStat11, type = "l", col="red")

spectrum(furStat12, type = "l", col="red")
spectrum(invFurStat12, type = "l", col="red")

# Correlation matrix
cor(data)
a = data$V1;
b = data$V4;
c = data$V10;
d = data$V11;

rab <- cor(a, b, method = "pearson")
rac <- cor(a, c, method = "pearson")
rad <- cor(a, d, method = "pearson")
rbc <- cor(b, c, method = "pearson")
rbd <- cor(b, d, method = "pearson")
rcd <- cor(c, d, method = "pearson")
print(rab)
print(rac)
print(rad)
print(rbc)
print(rbd)
print(rcd)

rab_c <- ((rab - rac * rbc) / sqrt((1 - rac) * (1 - rbc)))
print(rab_c)

rac_b <- ((rac - rab * rbc) / sqrt((1 - rab) * (1 - rbc)))
print(rac_b)

rab_cd <- ((rab - rac * rbc * rad * rbd) / sqrt((1 - rac) * (1 - rbc) * (1 - rad) * (1 - rbd)))
print(rab_cd)

rac_bd <- ((rac - rab * rbc * rad * rcd) / sqrt((1 - rab) * (1 - rbc) * (1 - rad) * (1 - rcd)))
print(rac_bd)

rad_bc <- ((rad - rab * rbd * rac * rcd) / sqrt((1 - rab) * (1 - rbd) * (1 - rac) * (1 - rcd)))
print(rad_bc)

ra_bc <- sqrt((rab * rab + rac * rac - 2 * rab * rac * rbc) / (1 - rbc * rbc))
print(ra_bc)

ra_bcd <- (1 - (1 - rab * rab) * (1 - rac_b * rac_b) * (1 - rad_bc * rad_bc))
print(ra_bcd)


# Factor analysis
corData <- cor(data)
eigenData <- eigen(corData)
print(eigenData$values)
plot(eigenData$values, type = "b", col="green")

print(eigenData$vectors)
print(eigenData$vectors %*% t(eigenData$vectors))

NormalizedCardioStat <- scale(data, center=TRUE, scale = TRUE)
MNormalizedCardioStat <- as.matrix(NormalizedCardioStat)
print(MNormalizedCardioStat)
res1 <- (MNormalizedCardioStat %*% t(eigenData$vectors[1:3,]))
print(res1)

plot(res1[,1], type = "l", col="green")
plot(res1[,2], type = "l", col="green")
plot(res1[,3], type = "l", col="green")


# Кластерний аналіз
CardioStat.kmeans7 <- kmeans(data, centers = 7)
hist(CardioStat.kmeans7$cluster)
print(CardioStat.kmeans7$cluster)

CardioStat.kmeans7 <- kmeans(data, centers = 5)
hist(CardioStat.kmeans7$cluster)
print(CardioStat.kmeans7$cluster)

MCardioStat.kmeans4 <- kmeans(res1, centers = 7)
hist(MCardioStat.kmeans4$cluster)
print(MCardioStat.kmeans4$cluster)

MCardioStat.kmeans4 <- kmeans(res1, centers = 5)
hist(MCardioStat.kmeans4$cluster)
print(MCardioStat.kmeans4$cluster)

