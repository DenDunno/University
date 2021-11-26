# 1.1. Hierarchical cluster analysis

distance = dist(menu, method="euclidean")

centroid = hclust(d=distance, method="centroid")
median = hclust(d=distance, method="median")
ward = hclust(d=distance, method="ward.D2")
average = hclust(d=distance, method="average")
single = hclust(d=distance, method="single")
complete = hclust(d=distance, method="complete")
mcquitty = hclust(d = distance, method = "mcquitty")

plot(centroid, main="Centroid method")
plot(median, main="Median method")
plot(ward, main="Ward's method")
plot(average, main="Average linkage")
plot(single, main="Nearest neighbor method")
plot(complete, main="Furthest neighbor method")
plot(mcquitty, main="McQuitty method")

cor(distance, cophenetic(centroid))
cor(distance, cophenetic(median))
cor(distance, cophenetic(ward))
cor(distance, cophenetic(average))
cor(distance, cophenetic(single))
cor(distance, cophenetic(complete))
cor(distance, cophenetic(mcquitty))


# 1.2 K-means

kMeans = kmeans(menu[2:3], 2)

fviz_cluster(kMeans, data=menu[2:3], palette="jco",
             choose.vars=c("Calories","Cholesterol"),
             ggtheme=theme_minimal(),
             cex.lab = 20)
