class Software:
    def __init__(self):
        self.id = None
        self.name = None
        self.Pagesize = None
        self.informationlistID = []
        self.informationlist = []

    def setAttributions(self, SID, SName, Pagesize, *LIDS):
        self.id = SID
        self.name = SName
        self.Pagesize = Pagesize
        self.informationlistID = [LID for LID in LIDS]


class InformationList:
    def __init__(self):
        self.id = None
        self.SoftwareID = None
        self.ListType = None
        self.RootNodeID = None
        self.RootNode = None

    def setAttributions(self, LID, SID, Listtype, NID):
        self.id = LID
        self.SoftwareID = SID
        self.ListType = Listtype
        self.RootNodeID = NID



class Node:
    def __init__(self):
        self.id = None
        self.name = None
        self.depth = None
        self.rank = None
        self.text = None

    def setAttributions(self, NID, Nrank, Depth, NName, NText):
        self.id = NID
        self.rank = Nrank
        self.depth = Depth
        self.name = NName
        self.text = NText


class NTree:
    def __init__(self, rootObj):
        self.key = rootObj
        self.child = []

    def appendChild(self, newNode):
        """鍙傛暟锛氫竴涓妭鐐瑰璞�
            鎻掑叆浠ヨ妭鐐瑰璞′负鏍圭殑N鍙夋爲"""
        self.child.append(NTree(newNode))

    def getChild(self, n):
        """N锛氳〃绀烘兂瑕佺N+1涓猚hild鑺傜偣
            杩斿洖绗琋+1涓猚hild鏍�"""
        return self.child[n]

    def setRootVal(self, obj):
        self.key = obj

    def getRootVal(self):
        return self.key


res = ''


def preorder(root):
    global res
    if not root:
        return

    res += root.key

    for i in root.child:
        preorder(i)
    return res


if __name__ == '__main__':
    r = NTree('a')
    r.appendChild('b')
    r.appendChild('c')
    r.getChild(0).appendChild('d')
    preorder(r)
    print(res)
