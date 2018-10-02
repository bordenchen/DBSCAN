library(jpeg)
library(grid)
library(raster)
library(grDevices)
library(ggplot2)
library(dbscan)
library(NbClust)
library(factoextra)
require(rpart)
require(tree)
library(rpart.plot)
require(rpart)


#------------------------------------get argument---------------------------------
args <- commandArgs()

Cluster <- args[2]

data_new<-read.csv("C:/Users/USER/Desktop/dataprocessing/classified_data.csv")
dat<-data_new[which(data_new$cluster == Cluster), ]

img<-ggplot(data=dat, aes(x=as.numeric(x_coordinate), y=as.numeric(y_coordinate), fill=rgb(V1,V2,V3))) +
  geom_tile()+scale_fill_identity()
print(img)
