# 1.
pairs(x[,1:5] , pch = 19 , 
      col = my_cols[iris$Species], 
      cex.labels = 1.4 , 
      main = 'Спостереження дощів у Лондоні за 2016 рік')


#2.
ggcorr(x,
       nbreaks = 10,
       label = TRUE,
       label_size = 14,
       label_round = 2,
       cex = 5,
       color = "black")


corrplot(cor(x),
         method='color',
         diag = FALSE)

         
#3. 

cor.test(x$`Реальна температура`, x$`Уявна температура`, method = "kendall")
