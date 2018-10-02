library(jpeg)
library(grid)
library(raster)
library(grDevices)
library(ggplot2)
library(dbscan)
img<-readJPEG("C:\\Users\\USER\\Desktop\\IMG_1281.JPG")

r_band<-img[,,1]
g_band<-img[,,2]
b_band<-img[,,3]
xy_location=function(x){
  x.col<-ncol(x)
  x.row<-nrow(x)
  x_coordinate<-sort(rep(1:x.col,x.row))
  y_coordinate<-rep(x.row:1,x.col)
  return(cbind(x_coordinate,y_coordinate))
}
r_xy<-cbind(as.list(r_band),as.list(g_band),as.list(b_band),xy_location(r_band))
r_band_df <- as.data.frame(r_xy)
y<-r_band_df[r_band_df$x_coordinate %in% c(1:100) & r_band_df$y_coordinate %in% c(1:100),]
ggplot(data=y, aes(x=as.numeric(x_coordinate), y=as.numeric(y_coordinate), fill=rgb(V1,V2,V3))) +
  geom_tile()+
  scale_fill_identity()
x_max<-max(unlist(r_band_df$x_coordinate))
x_slide<-x_max%/%100
y_max<-max(unlist(r_band_df$y_coordinate))
y_slide<-y_max%/%100
for (x in 1:x_slide){
  for(y in 1:y_slide){
    if(x==x_slide)
    {
      x_range<-c(((x-1)*100+1):x_max)
    }
    else
    {
      x_range<-c(((x-1)*100+1):((x-1)*100+100))
    }
    if(y==y_slide)
    {
      y_range<-c(((y-1)*100+1):y_max)
    }
    else
    {
      y_range<-c(((y-1)*100+1):((y-1)*100+100))
    }
    y<-r_band_df[r_band_df$x_coordinate %in% x_range & r_band_df$y_coordinate %in% y_range,]
    kmeans(y[,1:3],centers=2)
    
    print("prosessing")
  }
}

if (file.exists("C:/Users/USER/Desktop/dataprocessing/MyData.csv")) file.remove("C:/Users/USER/Desktop/dataprocessing/MyData.csv")
for (x in 1:x_max)
{
  
  y<-r_band_df[r_band_df[,4]==x,]
  y$cluster<-kmeans(y[,1:3],centers=2)$clust
  y <- apply(y,2,as.character)
  if(file.exists("C:/Users/USER/Desktop/dataprocessing/MyData.csv"))
  {
    write.table(y, file = "C:/Users/USER/Desktop/dataprocessing/MyData.csv",quote = FALSE, sep = ",",append = TRUE,col.names=FALSE,row.names = FALSE)
  }
  else
  {
    write.table(y, file = "C:/Users/USER/Desktop/dataprocessing/MyData.csv",col.names=TRUE,quote = FALSE,row.names = FALSE, sep = ",")
  }
  print("prosessing")
}
data<-read.csv("C:/Users/USER/Desktop/dataprocessing/MyData.csv")
dat<-data[data$cluster==2,]

ggplot(data=dat, aes(x=as.numeric(x_coordinate), y=as.numeric(y_coordinate), fill=rgb(V1,V2,V3))) +
  geom_tile()+
  scale_fill_identity()



kmeans(r_band_df[,1:3],centers=2)$withinss
r_band_df$clust <- kmeans(r_band_df[,1:3],centers=2)$clust

new_r<-ifelse(r_band_df$clust==1, 1,0)
r_band_df$new_r<-new_r
new_b<-ifelse(r_band_df$clust==2, 1,0)
r_band_df$new_b<-new_b
ggplot(data=r_band_df, aes(x=as.numeric(x_coordinate), y=as.numeric(y_coordinate), fill=rgb(new_b,0,0))) +
  geom_tile()+
  scale_fill_identity()
mean(unlist(r_band_df[r_band_df[,6]==1,1]))
mean(unlist(r_band_df[r_band_df[,6]==2,1]))
