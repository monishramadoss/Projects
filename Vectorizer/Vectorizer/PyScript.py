import csv
from collections import defaultdict
import json
from nltk.stem.porter import PorterStemmer
from textblob import TextBlob as tb
from textblob_aptagger import PerceptronTagger
from multiprocessing import Pool
import threading

Data = {"Sentance":list()}
KeyLst = dict()
pt = PerceptronTagger()

def tagger(str1):
    b1 = tb(str1,pos_tagger=pt)
    return [tag for word,tag in b1.tags]


def Stem(str1):
    str2 = [x for x in str1 if(x != '')]
    str0 = ''.join(str2)
    val = PorterStemmer().stem(str0)
    return val

def SenTAnalysis(string):
    sent = string[0].split(" ") 
    sentdata = zip([Stem(x) for x in sent],tagger(string[0]))
    wordset = ''
    for word,tag in sentdata:
        if(word.isalpha() and word != ''):
            wordset += word.replace('.','') + '#' + tag + ','
    return wordset[:-1] + '(' + string[1]
 
if __name__ == '__main__':

    with open(r"../t_data.csv") as f:
        reader = csv.reader(f, quotechar='"')
        pool = Pool(processes = 6)
        queueData = pool.map(SenTAnalysis,reader)
        
        Data['Sentance'] = queueData
        pool.close()
        pool.join()

    print(')'.join(Data['Sentance']).replace('.','').replace('\n',''))

    #file = open('./DataFiles/ScriptData.txt','w+')
    
    #file.write()
    #print('Data Write Complete')
    #print('Script Execution Complete')