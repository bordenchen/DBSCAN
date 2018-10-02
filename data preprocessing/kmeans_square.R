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
#summary(ecoli.rpart1)
#plotcp(ecoli.rpart1)
#rpart.plot(ecoli.rpart1)



#-------------------------------------data loading---------------------------------
img<-readJPEG(img_file)

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
RGB_xy<-cbind(as.list(r_band),as.list(g_band),as.list(b_band),xy_location(r_band))
RGB_band_df <- as.data.frame(RGB_xy)

#-------------------------------------data clustering -----------------------------

if (file.exists("C:/Users/USER/Desktop/dataprocessing/MyData.csv")) file.remove("C:/Users/USER/Desktop/dataprocessing/MyData.csv")
x_max<-max(unlist(RGB_band_df$x_coordinate))
x_slide<-x_max%/%10
y_max<-max(unlist(RGB_band_df$y_coordinate))
y_slide<-y_max%/%10
for (x in 1:x_slide){
  if(x==x_slide)
  {
    lkk<-RGB_band_df[(1+((x-1)*10*y_max)):(y_max*((x*10)+x_max%%10)),]
  }
  else
  {
    lkk<-RGB_band_df[(1+((x-1)*10*y_max)):(y_max*(x*10)),]
  }
  lkk <- as.data.frame(lapply(lkk, unlist))
  lkk<-lkk[order(lkk$y_coordinate),] 
  for(y in 1:y_slide)
  {
    
    
    if(y==y_slide)
    {
      slide_dat<-lkk[(1+((y-1)*10)):(10*((y*10)+y_max%%10)),]
      for(i in 2:15)
      {
        if((kmeans(slide_dat[,1:3],centers=i)$tot.withinss/kmeans(slide_dat[,1:3],centers=i)$betweenss)<=0.05)
        {
          slide_dat$cluster<-kmeans(slide_dat[,1:3],centers=i)$clust
          break()
        } 
        if(i==15)
        {
          slide_dat$cluster<-kmeans(slide_dat[,1:3],centers=1)$clust
          break()
        }
      }
      for(i in 0:(length(unique((slide_dat$cluster)))-1))
      {
        if(i>0)
        {
          cluster_data<-slide_dat[slide_dat$cluster==i,]
          R<-mean(unlist(cluster_data[,1]))
          G<-mean(unlist(cluster_data[,2]))
          B<-mean(unlist(cluster_data[,3]))
          mean_RGB<-as.data.frame(cbind(R,G,B))
          predict_class<-predict(class.rule,mean_RGB, type = "class")
          cluster_data$cluster<-predict_class
          cluster_data <- apply(cluster_data,2,as.character)
          if(file.exists("C:/Users/USER/Desktop/dataprocessing/MyData.csv"))
          {
            write.table(cluster_data, file = "C:/Users/USER/Desktop/dataprocessing/MyData.csv",quote = FALSE, sep = ",",append = TRUE,col.names=FALSE,row.names = FALSE)
          }
          else
          {
            write.table(cluster_data, file = "C:/Users/USER/Desktop/dataprocessing/MyData.csv",col.names=TRUE,quote = FALSE,row.names = FALSE, sep = ",")
          }
        }
      }
      
    }
    else
    {
      slide_dat<-lkk[(1+((y-1)*10)):(10*(y*10)),]
      for(i in 2:15)
      {
        if((kmeans(slide_dat[,1:3],centers=i)$tot.withinss/kmeans(slide_dat[,1:3],centers=i)$betweenss)<=0.05)
        {
          slide_dat$cluster<-kmeans(slide_dat[,1:3],centers=i)$clust
          break()
        } 
        if(i==15)
        {
          slide_dat$cluster<-kmeans(slide_dat[,1:3],centers=1)$clust
          break()
        }
      }
      for(i in 0:(length(unique((slide_dat$cluster)))-1))
      {
        if(i>0)
        {
          cluster_data<-slide_dat[slide_dat$cluster==i,]
          R<-mean(unlist(cluster_data[,1]))
          G<-mean(unlist(cluster_data[,2]))
          B<-mean(unlist(cluster_data[,3]))
          mean_RGB<-as.data.frame(cbind(R,G,B))
          predict_class<-predict(class.rule,mean_RGB, type = "class")
          cluster_data$cluster<-predict_class
          cluster_data <- apply(cluster_data,2,as.character)
          if(file.exists("C:/Users/USER/Desktop/dataprocessing/MyData.csv"))
          {
            write.table(cluster_data, file = "C:/Users/USER/Desktop/dataprocessing/MyData.csv",quote = FALSE, sep = ",",append = TRUE,col.names=FALSE,row.names = FALSE)
          }
          else
          {
            write.table(cluster_data, file = "C:/Users/USER/Desktop/dataprocessing/MyData.csv",col.names=TRUE,quote = FALSE,row.names = FALSE, sep = ",")
          }
        }
      }
 
    }
    
  }
  
}




#-------------------------------adjust csv File-------------------------------

data<-read.csv("C:/Users/USER/Desktop/dataprocessing/MyData.csv",stringsAsFactors=FALSE)
data<-data[complete.cases(data), ]
write.table(data, file = "C:/Users/USER/Desktop/dataprocessing/classified_data.csv",quote = FALSE, sep = ",",
            append = FALSE,col.names=TRUE,row.names = FALSE)



