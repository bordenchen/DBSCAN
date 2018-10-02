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
img_file <- args[3]
#------------------------------------predict rule generate------------------------

classified_result.df = read.csv(csv_file)
class.rule = tree(class ~ R+G+B,data = classified_result.df)


#-------------------------------------data loading---------------------------------
img<-readJPEG(img_file)
r_band<-img[,,1]
R<-as.list(img[,,1])
G<-as.list(img[,,2])
B<-as.list(img[,,3])
xy_location=function(x){
  x.col<-ncol(x)
  x.row<-nrow(x)
  x_coordinate<-sort(rep(1:x.col,x.row))
  y_coordinate<-rep(x.row:1,x.col)
  return(cbind(x_coordinate,y_coordinate))
}
RGB_xy<-cbind(R<-unlist(R),G<-unlist(G),B<-unlist(B),xy_location(r_band))
RGB_band_df <- as.data.frame(RGB_xy)


#-------------------------------save csv File-------------------------------

RGB_band_df$cluster<-predict(class.rule,RGB_band_df[,1:3],type = "class")

data<-RGB_band_df[complete.cases(RGB_band_df), ]
write.table(data, file = "C:/Users/USER/Desktop/dataprocessing/classified_data.csv",quote = FALSE, sep = ",",
            append = FALSE,col.names=TRUE,row.names = FALSE)

