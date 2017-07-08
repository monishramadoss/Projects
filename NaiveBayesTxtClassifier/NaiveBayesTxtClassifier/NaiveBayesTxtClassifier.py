
from collections import defaultdict

TrainData = ['I loved the movie', 'I hated the movie', 'A great movie good movie', 'poor acting', 'great acting a good movie']
ClassData = [0,1,0,1,0]

#tests for Unique words in a list of strings
def TestUnique(lst):
    templst = list()
    for x in lst:
        for word in x.split():
            word = word.replace('.','').replace(',','').replace('!','').replace('?','')
            if (word.lower() not in templst):
                templst.append(word.lower())
    return templst

#create document into feature vector
Unique_Words = TestUnique([j for j in TrainData])

#Vectorize a DB :: must only include STRINGs
def vectorize(ClassTrainData):
    SparseTable = list()
    #col is one of the value in unique data
    #row string index

    for i in range(len(Unique_Words)):
        SparseTable.append([])
    
    for y in range(len(ClassTrainData)):
        sent = ClassTrainData[y].replace('.','').replace(',','').replace('!','').replace('?','').replace("'",'')
        for x in range(len(Unique_Words)):       
            for word in sent.split():
                if(word.lower() == Unique_Words[x]):
                    SparseTable[x].append(y)
    return SparseTable


#outputs Proabality Stats
def ProbablityStat(wordIndex, TrainData, ClassData, TypeClass):

    vec = vectorize(TrainData)
    indexlst = [index for index in range(len(ClassData)) if ClassData[index] == TypeClass]
   
    n_val = 0
    for x in indexlst:
        for i in range(len(vec)):
            for val in vec[i]:
                if(val == x):
                    n_val += 1
       
    def findProb(index):
        n_k = 0
        for x in indexlst:
            for val in vec[index]:
                if(val == x):
                    n_k += 1
        return (n_k + 1)/(n_val + len(Unique_Words))    

    return findProb(wordIndex)
    

#Math is done all in this function 
def NaiveBayes(string,TrainData,ClassData):
    cases = list()
    for x in ClassData:
        if(x not in cases):
            cases.append(x)
    ProababilityData = list()Q

    for TypeClass in cases:
        Prob = list()
        for word in string.split():
            if(word.lower() in Unique_Words):    
                Prob.append(ProbablityStat(Unique_Words.index(word.lower()),TrainData,ClassData,TypeClass))
        print(Prob)

        tempval = 1.0
        for pval in Prob:
            tempval *= pval
        ProababilityData.append([TypeClass,ClassData.count(TypeClass)/len(ClassData) * tempval] )

    return sorted(ProababilityData,key = lambda x: -x[1],)

    
TestCase = "I loved the great acting in this movie"
print("Testcase is:: " + TestCase)
data = NaiveBayes(TestCase,TrainData,ClassData)
for i in data:
    print(i)
