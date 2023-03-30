import pymysql


class DataBase:
    def __init__(self):
        self.conn = pymysql.connect(host='101.43.94.40', user='root', password='2028295zY@', database='demo')
        self.cursor = self.conn.cursor()

    def query_strip(self):
        """将查询结果转换成二维列表"""
        data = self.cursor.fetchall()
        return [[j.strip() if type(j) == str else j for j in i] for i in data]

    def insert_software(self, softwareNode, trace):
        """
        :param softwareNode:
        :param trace:
        :功能：插入软件
        """
        sqlstr = f"insert into software(software_ID, software_Name, software_trace) values" \
                 f"({softwareNode.id},'{softwareNode.name}','{trace}')"
        self.cursor.execute(sqlstr)
        self.conn.commit()

    def insert_PLLeafNode(self, PLNode, softwareID):
        """

        :param PLNode:
        :param softwareID:
        :return:
        """
        sqlstr = f"insert into PersonalList(PLNode_ID, Software_ID, PLNode_Name, PLNode_Type)" \
                 f"values ({PLNode.id},{softwareID},'{PLNode.name}',1)"
        self.cursor.execute(sqlstr)
        sqlstr = f"insert into PLNode_Attributions(PLNode_ID, PLNode_Purpose, PLnode_UseCase, " \
                 f"PLNode_Collect_Situation, PLNode_Content)" \
                 f"values ({PLNode.id},'{PLNode.purpose}','{PLNode.usecase}',{PLNode.collectSituation},{PLNode.content})"
        self.cursor.execute(sqlstr)
        self.conn.commit()

    def insert_PLNode(self, PLNode, softwareID):
        """

        :param PLNode:
        :param softwareID:
        :return:
        """
        sqlstr = f"insert into PersonalList(PLNode_ID, Software_ID, PLNode_Name, PLNode_Type)" \
                 f"values ({PLNode.id},{softwareID},'{PLNode.name}',0)"
        self.cursor.execute(sqlstr)
        self.conn.commit()

    def insert_TLNode(self, TLNode, softwareID):
        """

        :param TLNode:
        :param softwareID:
        :return:
        """
        sqlstr = f"insert into ThirdList(TLNode_ID, software_ID, TLNode_Type, TLNode_OS, TLNode_Name, TLNode_Company, " \
                 f"TLNode_InformationContent, TLNode_Purpose, TLNode_UseCase, TLNode_Way, TLNode_Detailed)" \
                 f"values({TLNode.id},{softwareID},'{TLNode.type}','{TLNode.os}','{TLNode.name}','{TLNode.com}','{TLNode.content}','{TLNode.purpose}','{TLNode.scene}','{TLNode.collect}','{TLNode.url}') "
        self.cursor.execute(sqlstr)
        self.conn.commit()

    def insert_Relation(self, relation):
        """

        :param relation:
        :return:
        """
        sqlstr = f"insert into PLNode_Relation(Parent_ID, Child_ID) " \
                 f"values({relation[0]},{relation[1]})"
        self.cursor.execute(sqlstr)
        self.conn.commit()
