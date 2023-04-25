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

import csv
from sklearn.metrics import confusion_matrix
from sklearn.metrics import ConfusionMatrixDisplay
from sklearn.metrics import precision_score
from sklearn.metrics import recall_score

# 打开test文件
file1 = open(r"C:\Users\deng\Desktop\InformationAnalysis\Cluster\testDataNew.csv", encoding='gbk', errors='ignore')
file1reader = csv.reader(file1)
file1data = list(file1reader)
# 将index和prelabel存入字典
data1 = {}
for i in file1data[1:]:
    p = i[1:2][0]
    q = int(i[4:5][0])
    data1[p] = q

# 打开train文件
file2 = open(r"C:\Users\deng\Desktop\InformationAnalysis\Cluster\new_useful.csv", encoding='gbk', errors='ignore')
file2reader = csv.reader(file2)
file2data = list(file2reader)

# 将train文件的index和各项标签存入字典
data2 = {}
data2polarity = {}
for i in file2data[1:]:
    q = []
    p = i[1:2][0]
    a = i[10:11][0]
    if a == '1':
        a = 1
    else:
        a = 0
    q.append(a)
    b = i[11:12][0]
    if b == '1':
        b = 1
    else:
        b = 0
    q.append(b)
    c = i[12:13][0]
    if c == '1':
        c = 1
    else:
        c = 0
    q.append(c)
    d = i[13:14][0]
    if d == '1':
        d = 1
    else:
        d = 0
    q.append(d)
    e = i[14:15][0]
    if e == '1':
        e = 1
    else:
        e = 0
    q.append(e)
    f = i[15:16][0]
    if f == '1':
        f = 1
    else:
        f = 0
    q.append(f)
    g = i[16:17][0]
    if g == '1':
        g = 1
    else:
        g = 0
    q.append(g)
    h = i[17:18][0]
    if h == '1':
        h = 1
    else:
        h = 0
    q.append(h)
    data2[p] = q
# 进行polarity混淆矩阵的制作
ypolarity_true = []
ypolarity_prediction = []
for i in data1.keys():
    if i in data2.keys():
        ypolarity_true.append(data1[i])
        ypolarity_prediction.append(data2[i][0])
cmpolarity = confusion_matrix(ypolarity_true, ypolarity_prediction)
cmpolarity_display = ConfusionMatrixDisplay(cmpolarity).plot()
print(precision_score(ypolarity_true, ypolarity_prediction))
print(recall_score(ypolarity_true, ypolarity_prediction))

# 进行newlength混淆矩阵的制作
ynewlength_true = []
ynewlength_prediction = []
for i in data1.keys():
    if i in data2.keys():
        ynewlength_true.append(data1[i])
        ynewlength_prediction.append(data2[i][1])
cmnewlength = confusion_matrix(ynewlength_true, ynewlength_prediction)
cmnewlength_display = ConfusionMatrixDisplay(cmnewlength).plot()
print(precision_score(ynewlength_true, ynewlength_prediction))
print(recall_score(ynewlength_true, ynewlength_prediction))

# 进行ratio混淆矩阵的制作
yratio_true = []
yratio_prediction = []
for i in data1.keys():
    if i in data2.keys():
        yratio_true.append(data1[i])
        yratio_prediction.append(data2[i][2])
cmratio = confusion_matrix(yratio_true, yratio_prediction)
cmratio_display = ConfusionMatrixDisplay(cmratio).plot()
print(precision_score(yratio_true, yratio_prediction))
print(recall_score(yratio_true, yratio_prediction))

# 进行PCA混淆矩阵的制作
yPCA_true = []
yPCA_prediction = []
for i in data1.keys():
    if i in data2.keys():
        yPCA_true.append(data1[i])
        yPCA_prediction.append(data2[i][3])
cmPCA = confusion_matrix(yPCA_true, yPCA_prediction)
cmPCA_display = ConfusionMatrixDisplay(cmPCA).plot()
print(precision_score(yPCA_true, yPCA_prediction))
print(recall_score(yPCA_true, yPCA_prediction))

# 进行three混淆矩阵的制作
ythree_true = []
ythree_prediction = []
for i in data1.keys():
    if i in data2.keys():
        ythree_true.append(data1[i])
        ythree_prediction.append(data2[i][4])
cmthree = confusion_matrix(ythree_true, ythree_prediction)
cmthree_display = ConfusionMatrixDisplay(cmthree).plot()
print(precision_score(ythree_true, ythree_prediction))
print(recall_score(ythree_true, ythree_prediction))

# 进行ALL混淆矩阵的制作
yALL_true = []
yALL_prediction = []
for i in data1.keys():
    if i in data2.keys():
        yALL_true.append(data1[i])
        yALL_prediction.append(data2[i][5])
cmALL = confusion_matrix(yALL_true, yALL_prediction)
cmALL_display = ConfusionMatrixDisplay(cmALL).plot()
print(precision_score(yALL_true, yALL_prediction))
print(recall_score(yALL_true, yALL_prediction))

# 进行PCAnew混淆矩阵的制作
yPCAnew_true = []
yPCAnew_prediction = []
for i in data1.keys():
    if i in data2.keys():
        yPCAnew_true.append(data1[i])
        yPCAnew_prediction.append(data2[i][6])
cmPCAnew = confusion_matrix(yPCAnew_true, yPCAnew_prediction)
cmPCAnew_display = ConfusionMatrixDisplay(cmPCAnew).plot()
print(precision_score(yPCAnew_true, yPCAnew_prediction))
print(recall_score(yPCAnew_true, yPCAnew_prediction))

# 进行ALLnew混淆矩阵的制作
yALLnew_true = []
yALLnew_prediction = []
for i in data1.keys():
    if i in data2.keys():
        yALLnew_true.append(data1[i])
        yALLnew_prediction.append(data2[i][7])
cmALLnew = confusion_matrix(yALLnew_true, yALLnew_prediction)
cmALLnew_display = ConfusionMatrixDisplay(cmALLnew).plot()
print(precision_score(yALLnew_true, yALLnew_prediction))
print(recall_score(yALLnew_true, yALLnew_prediction))
