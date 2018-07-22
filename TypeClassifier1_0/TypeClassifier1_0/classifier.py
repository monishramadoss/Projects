from __future__ import print_function

# https://www.youtube.com/watch?v=ZiKMIuYidY0

from sklearn.feature_extraction.text import CountVectorizer
import pandas as pd

pathobj = open('Data.xlsx', 'rb')
reqTable = pd.read_excel(pathobj,sheetname = 0,header = None, names= ['requests','TypeClass'])
reqTable['TypeClass_num'] = reqTable.TypeClass.map({'mail':0,'cleaning':1,'delivery':2,'take':3 })

X = reqTable.requests
y = reqTable.TypeClass_num

vect = CountVectorizer(token_pattern=u'(?u)\\b\\D\\D*\\b')
X_train_dtm = vect.fit_transform(X)

print(reqTable.TypeClass.value_counts())

# Naive_Bayes (Dtm->Fit->Predict)

inputval = input("Commands (mail,cleaning,delivery,take): ")
Test_Data = [inputval] #['Get me a burger']


from sklearn.naive_bayes import MultinomialNB
nb = MultinomialNB()
nb.fit(X_train_dtm,y)
X_test_dtm = vect.transform(Test_Data)
yPredict = nb.predict(X_test_dtm)

print(yPredict)
for x in yPredict:
    if(x == 0):
        print('mail')
    if(x == 1):
        print('cleaning')
    if(x == 2):
        print('delivery')
    if(x == 3):
        print('take')

print("Traing data has made it biased towards :: take")