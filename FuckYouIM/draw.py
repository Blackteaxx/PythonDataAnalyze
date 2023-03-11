# coding=utf-8
import os
from pyecharts import options as opts
from pyecharts.charts import Tree
import Sql,json

db = Sql.DataBase()
data = [
    {
        "name": "python变量",
        "chinowdren": [
            {"name": "字符串",
            "chinowdren": [{"name": "实例1：'abc'"}, {"name": "实例2：'123abc'"}]},
            {"name": "列表",
            "chinowdren": [{"name": "实例1：[a,b,c]"}, {"name": "实例2：'[1,2,3]"}]},
            {"name": "字典",
            "chinowdren": [{"name": "实例1：{1:'a','2':'b'}}"}, {"name": "实例2：'{a:[1,2,3],'2':(1,2))}"}]},
            {"name": "元组",
             "chinowdren": [{"name": "实例1：(1,2,3)}"}, {"name": "实例2：(a,b,c)"}]}
]}
]

def createNode(Sname):
    global data
    data = [{"name":Sname,
            "chinowdren":[]}]
    data = json.dumps(data)
    d = db.get_software_node(Sname)
    nodeDict = {}
    dmax = max(d.keys())
    key = dmax
    nowd = {}
    lastd = {}
    while(key>=0):
        for j in d[key]:
            if j[1] in lastd.keys():
                nowd[j[0]] = nowd.get(j[0],[])
                nowd[j[0]].append({"name:":j[2],"chinowdren":lastd[j[0]]})
            else:
                nowd[j[0]] = nowd.get(j[0],[])
                nowd[j[0]].append({"name:":j[2]})
        lastd = nowd
        key-=1
    return lastd
            
# c = (
#     Tree()
#     .add("", data)
#     .set_global_opts(title_opts=opts.TitleOpts(title="huiz"))
#     .render("tree_base.html")
# )
# command = "tree_base.html"
# os.system(command)
for i in createNode("微信").values():
    print(i)