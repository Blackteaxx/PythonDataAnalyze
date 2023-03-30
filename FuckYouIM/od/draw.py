# coding=utf-8
import os
from pyecharts import options as opts
from pyecharts.charts import Tree
import Sql, json

db = Sql.DataBase()


def createTreePic(Sname: str, isOpen=True, htmlNmae="tree_base.html"):
    '''Sname为应用名字，isOpen决定在生成后打开是否打开，htmlName为生成的HTML文件名字'''
    d = db.get_software_node(Sname)
    if len(d.values()) == 0:
        print("不存在此应用！")
        return
    dmax = max(d.keys())
    key = dmax
    lastd = {}
    while key >= 0:
        nowd = {}
        for j in d[key]:
            if j[1] in lastd.keys():
                nowd[j[0]] = nowd.get(j[0], [])
                nowd[j[0]].append({"children": lastd[j[1]], "name": j[2]})
            else:
                nowd[j[0]] = nowd.get(j[0], [])
                nowd[j[0]].append({"name": j[2]})
        lastd = nowd
        key -= 1
    data = [{"children": list(lastd.values())[0], "name": Sname}]
    c = (
        Tree()
            .add("", data)
            .set_global_opts(title_opts=opts.TitleOpts(title=Sname))
            .render(htmlNmae)
    )
    if isOpen:
        os.system(htmlNmae)


print(createTreePic("微信"))
