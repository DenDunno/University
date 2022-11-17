
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

as.data.frame(scale(data)) #normalization


# ANOVA
tempData = data
summary(aov(tempData))
aov(values   ~ ind, stack(tempData))


# Correlation matrix
cor(data, method = c("pearson", "kendall", "spearman"))


#Factor analysis
values = eigen(cor(data, method = c("pearson", "kendall", "spearman")))
values$values
values$vectors
