from Tree2 import NTree, Node, Software, InformationList
from Sql import DataBase

DB = DataBase()


def instance_Node():
    """实例化软件的所有节点"""

    Nodelist = []
    nodeAttributions = DB.get_node()

    print(nodeAttributions)
    for node in nodeAttributions:
        Nodei = Node()
        Nodei.setAttributions(node[0], node[1], node[2], node[3], node[4])
        Nodelist.append(Nodei)

    print(Nodelist)
    return Nodelist


Nodelist = instance_Node()


def find_Node(NID):
    """根据NID在Nodelist找出需要的实例化Node
        返回：Node"""

    for Nodei in Nodelist:
        if Nodei.id == NID:
            return Nodei

    return False


def instance_Tree(RootNode):
    """实例化给出根节点的多叉树
        递归实现"""

    ChildIDs = DB.get_ChildNode(RootNode.key.id)

    for ChildID in ChildIDs:
        ChildNode = find_Node(ChildID)
        RootNode.appendChild(ChildNode)

    if not RootNode.child:
        return
    else:
        for childTreeroot in RootNode.child:
            instance_Tree(childTreeroot)


def instance_Software():
    """获取所有软件的信息
        返回实例化的所有软件"""

    Softwarelist = []
    softwareAttribution = DB.get_software()

    print(softwareAttribution)

    # 实例化软件列表
    for software in softwareAttribution:
        Softwarei = Software()
        Softwarei.setAttributions(software[0], software[1], software[2], software[3], software[4])
        Softwarelist.append(Softwarei)

    print(Softwarelist)

    # 实例化软件的清单
    for Softwarei in Softwarelist:
        LIDS = Softwarei.informationlistID
        print(LIDS)

        # 根据LID实例化informationlist
        for LID in LIDS:
            informationlist_attributions = DB.get_informationlist(LID)
            print(informationlist_attributions)
            InformationListi = InformationList()
            InformationListi.setAttributions(informationlist_attributions[0], informationlist_attributions[1],
                                             informationlist_attributions[2], informationlist_attributions[3])
            Softwarei.informationlist.append(InformationListi)

        print(Softwarei.informationlist)

        # 实例化路径树
        for InformationListi in Softwarei.informationlist:
            NID = InformationListi.RootNodeID
            Nodei = find_Node(NID)
            RootNode = NTree(Nodei)
            instance_Tree(RootNode)
            InformationListi.RootNode = RootNode

    return Softwarelist


if __name__ == '__main__':
    instance_Software()
    instance_Node()
