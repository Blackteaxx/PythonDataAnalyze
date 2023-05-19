from flask import Flask
from datetime import datetime
import os
import time
import markdown

from exts import db
from models import Section, Blog


def add_section(folder_name):
    # 根据文件夹名加入section
    section = Section.query.filter_by(section_name=folder_name).first()
    if section:
        return section.sid
    else:
        section = Section(section_name=folder_name, section_description="")
        db.session.add(section)
        db.session.commit()
        return section.sid


def read_blog(path):
    """
    从文件解析元数据
    :param path: 路径
    :return: 包含数据的字典
    """
    with open(path, "r", encoding="utf-8") as f:
        content = f.read()
        md = markdown.Markdown(extensions=["meta"])
        md.convert(content)
        title = md.Meta.get("title", "")[0]

        # 若blog已存在
        blog = Blog.query.filter_by(blog_name=title).first()
        if blog:
            return {
                "title": title
            }
        # 若不存在
        else:
            author = md.Meta.get("author", "")[0]
            section_name = os.path.basename(os.path.dirname(path))
            section_id = add_section(section_name)
            return {
                "title": title,
                "author": author,
                "sid": section_id
            }


def save_sections_blogs(sync_interval):
    # 手动创建应用程序上下文
    from app import app
    with app.app_context():
        while True:
            # 创建section
            for folder_name in os.listdir("./static/doc"):
                add_section(folder_name)
                # 创建博客
                for file_name in os.listdir(f"./static/doc/{folder_name}"):
                    if file_name[-2:] == "md":
                        path = f"./static/doc/{folder_name}/{file_name}"
                        blog_data = read_blog(path)
                        if blog_data:
                            try:
                                blog = Blog.query.filter_by(blog_name=blog_data["title"]).first()
                                if blog is None:
                                    blog = Blog(
                                        create_time=datetime.now(),
                                        blog_name=blog_data["title"],
                                        author=blog_data["author"],
                                        sid=blog_data["sid"],
                                        file_name=path
                                    )
                                    db.session.add(blog)
                                    db.session.commit()
                                else:
                                    blog.blog_name = blog_data["title"]
                                    db.session.merge(blog)
                                    db.session.commit()
                            except Exception as e:
                                db.session.rollback()
                                print(f'An error occurred when storing blog {blog_data["title"]} to database: {e}')
            time.sleep(sync_interval)