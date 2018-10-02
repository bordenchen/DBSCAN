require(rpart)
require(tree)
library(rpart.plot)
ecoli.df = read.csv("C:/Users/USER/Desktop/dataprocessing/result.csv")
ecoli.rpart1 = rpart(class ~ R+G+B,data = ecoli.df)
summary(ecoli.rpart1)
plotcp(ecoli.rpart1)
rpart.plot(ecoli.rpart1)



ecoli.tree1 = tree(class ~ R+G+B,data = ecoli.df)
summary(ecoli.tree1)
plot(ecoli.tree1)
text(ecoli.tree1, all = T)
Cv_Tree<-cv.tree(ecoli.tree1,FUN = prune.misclass)
plot(Cv_Tree)
treePrunedMod <- prune.misclass(ecoli.tree1, best = 4)
plot(treePrunedMod)

data<-ecoli.df[,1:3]
R<-0.1
G<-0.5
B<-0.3
dad<-as.data.frame(cbind(R,G,B))

out <- predict(ecoli.tree1 ,ecoli.df[,1:3] , type = "class")
out_df<-as.data.frame(out)
out_df$class<-ecoli.df[,4]

