args <- commandArgs()
riskValueFilepath <- args[2]
VaR <- args[3]

data <- read.csv(riskValueFilepath, header = TRUE)
attach(data)
x <- strptime(data$date, '%Y%m%d', tz = '')

par(xaxt = 'n')

plot(x, data$risk_value, type = 'n', xlab = '',ylab ='')
lines(x, data$risk_value, type = 'l',col = 'thistle4',add = T)
points(x, data$risk_value, type = 'p',pch = 20,col = ifelse(data$risk_value > VaR, 'tomato', 'thistle4'), add = T)

par(xaxt = 's')

y <- as.POSIXct(round(range(x), "days"))
axis.POSIXct(1,at = seq(y[1],y[2],by = "1 day"),format = '%Y%m%d')
title('Test of Integrating C# and R\n(Points above Value at Risk)', xlab = 'Date',ylab = 'Risk Value')