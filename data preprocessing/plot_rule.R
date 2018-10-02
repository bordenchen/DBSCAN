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
csv_file <- args[2]

#------------------------------------predict rule generate------------------------

classified_result.df = read.csv(csv_file)
class.rule = tree(class ~ R+G+B,data = classified_result.df)
#class.rule2 = rpart(class ~ R+G+B,data = classified_result.df)

plot(class.rule)
text(class.rule, all = T)

