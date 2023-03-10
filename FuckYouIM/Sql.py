import pymysql


class DataBase:
    def __init__(self):
        self.conn = pymysql.connect(host='101.43.94.40', user='root', password='2028295zY@', database='tree')
        self.cursor = self.conn.cursor()

    def query_strip(self):
        """将查询结果转换成二维列表"""

        data = self.cursor.fetchall()
        return [[j.strip() if type(j) == str else j for j in i] for i in data]

    def get_software(self):
        """获取所有软件及其信息表的信息
                返回二维列表[[SID, SName, Pagesize, LID1, LID2]]"""

        self.cursor.execute("select SID, SName, Pagesize from software")
        Softwarelist = self.query_strip()

        # 寻找LID
        for list in Softwarelist:
            SID = list[0]
            self.cursor.execute(f"select LID from informationlist where SID = {SID}")
            LIDlist = self.query_strip()

            for LID in LIDlist:
                list.append(LID[0])

        return Softwarelist

    def get_informationlist(self, LID):
        """根据LID返回Informationlist的所有信息
            参数：LID
            返回列表[LID, SID, Listtype, NID]"""

        self.cursor.execute(f"select LID, SID, Listtype, NID from informationlist where LID = {LID}")
        return self.query_strip()[0]

    def get_node(self):
        """返回二维列表[[NID, Nrank, Depth, NName, NText]]"""
        self.cursor.execute("select * from node")
        return self.query_strip()

    def get_ChildNode(self, FatherID):
        """根据给出FatherID返回直接ChildID(根据rank排序)
            参数：FatherID
            返回列表[ChildID1, ChildID2...]"""
        self.cursor.execute(
            f"select ChildID from noderelation , node where FatherID = {FatherID} and node.NID = noderelation.childid order by Nrank")
        templist = self.query_strip()
        ChildIDs = [ChildID[0] for ChildID in templist]
        return ChildIDs


if __name__ == '__main__':
    db = DataBase()
    print(db.get_software())
    print(db.get_informationlist(1))
    print(db.get_node())
