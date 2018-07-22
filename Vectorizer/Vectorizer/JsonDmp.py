import json
from collections import defaultdict


output = r"../Output.json"
data = defaultdict(dict)

Err = list()

txtData = input()

for i in txtData.split('**')[:-1]:
    if(len(i.split('::')) == 2):
        val,word = i.split('::') 
        wp = word.split(',')
        data[val][wp[0]] = wp[1]
    else:
        Err.append(i)
        
if(len(Err) != 0):
    raise TypeError(str(Err))

with open(output, 'w+') as o:
    json.dump(data,o)
    