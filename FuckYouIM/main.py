import xml.dom.minidom as XmlDocument
import xml
from db import DataBase


def isLeafNodeAttribution(element):
    if "：" in element.getAttribute("text"):
        return True
    else:
        return False


def isLeafNode(PLNode):
    if PLNode.purpose is not None:
        return True
    else:
        return False


class Node:
    @staticmethod
    def findNode(lst, name):
        for node in lst:
            if node.name == name:
                return node

    def __init__(self, name, id):
        self.name = name
        self.id = id
        self.purpose = None
        self.usecase = None
        self.collectSituation = None
        self.content = None

    def setLeafAttributions(self, purpose, usecase, collectSituation, content):
        self.purpose = purpose
        self.usecase = usecase
        self.collectSituation = collectSituation
        self.content = content

    def setLeafAttribution(self, text):
        temp = text.split("：")
        if "目的" in temp[0]:
            self.purpose = temp[1]
        elif "场景" in temp[0]:
            self.usecase = temp[1]
        elif "情况" in temp[0]:
            self.collectSituation = temp[1]
        elif "内容" in temp[0]:
            self.content = temp[1]


class ShareNode:
    def __init__(self):
        self.id = 0
        self.name = 0
        self.type = 0
        self.os = 0
        self.com = 0
        self.content = 0
        self.purpose = 0
        self.scene = 0
        self.collect = 0
        self.url = 0

    def setInfo(self, infoLst):
        self.id = infoLst[0]
        self.name = infoLst[1]
        self.type = infoLst[2]
        self.os = infoLst[3]
        self.com = infoLst[4]
        self.content = infoLst[5]
        self.purpose = infoLst[6]
        self.scene = infoLst[7]
        self.collect = infoLst[8]
        self.url = infoLst[9]

    def __str__(self) -> str:
        return f"""
                编号：{self.id}
                名字：{self.name}
                类型：{self.type}
                操作系统：{self.os}
                公司：{self.com}
                信息内容：{self.content}
                收集目的：{self.purpose}
                收集场景：{self.scene}
                收集方式:{self.collect}
                隐私政策：{self.url}
                """


def parseOpml(filepath):
    """解析opml
        返回[[PLNode],[TLNode],[NodeRelation]]"""

    doc = XmlDocument.parse(filepath)

    # 读取NodeID
    with open("NodeID.txt", "r") as fp:
        nodeId = int(fp.readline())

    print(nodeId)

    # 获取body元素的数据
    node = doc.getElementsByTagName('body')[0]
    nodeLst = []
    shareNodeLst = []
    relationLst = []
    personNodeId = -1
    shareNodeId = -1

    # 获取头部outline数据，实例化进入列表
    elementLst = [i for i in node.childNodes if isinstance(i, xml.dom.minidom.Element)]
    print(elementLst)
    PLNode = Node(elementLst[0].getAttribute("text"), nodeId)
    nodeLst.append(PLNode)
    nodeId += 1

    while len(elementLst) != 0:
        newElementLst = []
        for parent in elementLst:

            # 获取父节点信息
            parent_name = parent.getAttribute("text")
            parentNode = Node.findNode(nodeLst, name=parent_name)
            parent_id = parentNode.id
            if parent_id == shareNodeId:
                for child in parent.childNodes:
                    if not isinstance(child, xml.dom.minidom.Element):
                        continue
                    shareNodeInfo = [nodeId, child.getAttribute("text")]
                    relationLst.append((parent_id, nodeId))
                    nodeId += 1
                    for attribute in child.childNodes:
                        if not isinstance(attribute, xml.dom.minidom.Element):
                            continue
                        shareNodeInfo.append(attribute.getAttribute("text").split("：")[1])
                    s = ShareNode()
                    s.setInfo(shareNodeInfo)
                    shareNodeLst.append(s)
            else:
                for child in parent.childNodes:
                    if isinstance(child, xml.dom.minidom.Element):
                        child_name = child.getAttribute("text")

                        # 判断节点是否为属性内容
                        if isLeafNodeAttribution(child):
                            parentNode.setLeafAttribution(child_name)
                        else:
                            if child_name == "第三方信息共享清单":
                                shareNodeId = nodeId
                            elif child_name == "个人信息收集清单":
                                personNodeId = nodeId
                            newElementLst.append(child)
                            PLNode = Node(child_name, nodeId)
                            nodeLst.append(PLNode)
                            relationLst.append((parent_id, nodeId))
                            nodeId += 1
        elementLst = list(newElementLst)

    # 写入NodeID
    with open("NodeID.txt", "w") as fp:
        fp.write(str(nodeId + 1))

    for PLNode in nodeLst:
        print(f"ID : {PLNode.id}, NAME: {PLNode.name}, Purpose:{PLNode.purpose}")
    for i in shareNodeLst:
        print(i)
    print(relationLst)

    return [nodeLst, shareNodeLst, relationLst]


def InsertAllNodes(filepath, db):
    # 解析Opml
    reslst = parseOpml(filepath)
    PLNodeLst = reslst[0]
    TLNodeLst = reslst[1]
    PLNodeRelation = reslst[2]

    softwareNode = PLNodeLst[0]
    softwareID = softwareNode.id
    del PLNodeLst[0]

    # 清理节点
    traceNode = [PLNodeLst[0], PLNodeLst[1]]
    PLNodeLst.remove(traceNode[0])
    PLNodeLst.remove(traceNode[1])

    values = []
    for index in range(len(PLNodeRelation)):
        for Node in traceNode:
            if Node.id in PLNodeRelation[index]:
                values.append(PLNodeRelation[index])

    values = set(values)

    for value in values:
        PLNodeRelation.remove(value)

    trace = f"{traceNode[0].name}-{traceNode[1].name}"

    print(PLNodeRelation)
    print(trace)

    # 清理第三方节点
    id = None
    for PLNode in PLNodeLst:
        if PLNode.name == "第三方信息共享清单":
            id = PLNode.id
            PLNodeLst.remove(PLNode)
    print(id)
    values = []
    for relation in PLNodeRelation:
        if id == relation[0]:
            values.append(relation)

    print(values)
    for value in values:
        PLNodeRelation.remove(value)

    # Software 入库
    db.insert_software(softwareNode, trace)

    # PLNode 入库
    for PLNode in PLNodeLst:
        if isLeafNode(PLNode):
            db.insert_PLLeafNode(PLNode, softwareID)
        else:
            db.insert_PLNode(PLNode, softwareID)

    # TLNode 入库
    for TLNode in TLNodeLst:
        db.insert_TLNode(TLNode, softwareID)

    # PLNodeRelation 入库
    for relation in PLNodeRelation:
        db.insert_Relation(relation)


if __name__ == '__main__':
    db = DataBase()
    InsertAllNodes("bilibili.opml", db)
