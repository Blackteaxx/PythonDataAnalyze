import nltk
from nltk.tokenize import word_tokenize
# NN     noun, singular 'desk' 名词单数形式
# NNS    nounplural  'desks'  名词复数形式
# NNP    propernoun, singular     'Harrison' 专有名词
# NNPS  proper noun, plural 'Americans'  专有名词复数形式
# PDT    predeterminer      'all the kids'  前位限定词
# DT     determiner  限定词（置于名词前起限定作用，如 the、some、my 等）
# JJ     adjective    'big'  形容词
# JJR    adjective, comparative 'bigger' （形容词或副词的）比较级形式
# JJS    adjective, superlative 'biggest'  （形容词或副词的）最高级
import pandas as pd
df = pd.read_csv("D://paper/git/PythonDataAnalyze/PCA&Clustered/preProcessdata.csv")
targetList = ["NN","NNS","NNP","NNPS","PDT","DT","JJ","JJR","JJS"]
def countWord(text):
    s = word_tokenize(text)
    PartOfSpeech = nltk.pos_tag(s)
    slen = 0
    wordWorthNum = 0
    for i,j in PartOfSpeech:
        if j!='.':
            slen+=1
            if j in targetList:
                wordWorthNum+=1
    return slen,"{:.2f}".format(wordWorthNum/slen)
from tqdm import trange
for i in trange(360000):
    # do something
    try:
        countWord(df["Comment (Actual)"][i])
    except:
        print(i)