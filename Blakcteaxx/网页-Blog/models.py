from exts import db
from datetime import datetime


class UserModel(db.Model):
    __tablename__ = "user"
    uid = db.Column(db.Integer, primary_key=True, autoincrement=True)
    username = db.Column(db.String(100), nullable=False)
    password = db.Column(db.String(300), nullable=False)
    email = db.Column(db.String(100), nullable=False, unique=True)
    join_time = db.Column(db.DateTime, default=datetime.now)
    is_staff = db.Column(db.Boolean, nullable=True, default=False)


class Section(db.Model):
    __tablename__ = "section"
    sid = db.Column(db.Integer, primary_key=True, autoincrement=True)
    section_name = db.Column(db.String(100), nullable=False, unique=True)


class Blog(db.Model):
    __tablename__ = "blog"
    bid = db.Column(db.Integer, primary_key=True, autoincrement=True)
    file_name = db.Column(db.String(100), nullable=False, unique=True)
    create_time = db.Column(db.DateTime, default=datetime.now)
    blog_name = db.Column(db.String(100), nullable=False, unique=True)
    author = db.Column(db.String(100), nullable=False)

    # 关联
    sid = db.Column(db.Integer, db.ForeignKey("section.sid"))
    section = db.relationship("Section", backref="section")
