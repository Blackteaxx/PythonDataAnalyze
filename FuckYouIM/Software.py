import pymysql


class DataBase:
    def __init__(self):
        self.conn = pymysql.connect(host='101.43.94.40', user='root', password='2028295zY@', database='tree')
        self.cursor = self.conn.cursor()

    def query_strip(self):
        """将查询结果转换成二维列表"""

        data = self.cursor.fetchall()
        return [[j.strip() if type(j) == str else j for j in i] for i in data]


db = DataBase()
db.cursor.execute("select * from software")
res = db.query_strip()
print(res)
