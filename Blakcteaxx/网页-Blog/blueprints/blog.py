from flask import Blueprint, render_template, request, url_for
from sqlalchemy import func

from models import Section, Blog
import random
import subprocess
import os
import signal
import markdown
from markdown.extensions.attr_list import AttrListExtension

bp = Blueprint("blog", __name__, static_url_path="/static",
               static_folder="/static", url_prefix="/")


def write_to_temp_file(tmp_file, text):
    with open(tmp_file, "w") as f:
        f.write(text)


import subprocess
import time
import os


def run(code):
    try:
        exe_file = "./static/Clox.exe"
        tmp_file = "./static/tmp_script.txt"

        # 将代码写入临时文件中
        write_to_temp_file(tmp_file, code)

        args = [tmp_file]  # 替换成你需要传递给可执行文件的参数

        # 设置超时时间为 1 秒
        timeout_sec = 1

        # 启动计时器
        start_time = time.time()

        # 使用 subprocess.Popen 运行可执行文件
        process = subprocess.Popen([exe_file] + args, stdout=subprocess.PIPE, stderr=subprocess.PIPE)

        while process.poll() is None:
            # 进程还在运行，等待 10 毫秒后继续检查状态
            time.sleep(0.01)

            # 检查是否超过了规定的时间
            elapsed_time = time.time() - start_time
            if elapsed_time > timeout_sec:
                # 超时，杀死进程
                process.kill()
                raise TimeoutError()

        # 等待可执行文件返回结果
        stdout, stderr = process.communicate()

        # 存储结果以便在新窗口中展示
        result = stdout.decode()
        error = stderr.decode()

    except subprocess.CalledProcessError as e:
        # 如果执行出错，输出错误信息
        result = e.output
        error = ""

    except TimeoutError:
        # 如果执行超时，输出 timeout
        result = ""
        error = "timeout"

    write_to_temp_file(tmp_file, "")
    return (result, error)


# 首页
@bp.route("/")
def index():
    # 随机查询三个记录
    sections = Section.query.order_by(func.random()).limit(3).all()

    with open("./static/Introduction/index.md", "r", encoding="utf-8") as f:
        content = f.read()

    md = markdown.Markdown()
    html = md.convert(content)

    return render_template("index.html", introduction=html, sections=sections)


# 代码
@bp.route("/code", methods=["GET", "POST"])
def code():
    if request.method == "GET":
        return render_template("codeeditor.html", code="", result="")
    else:
        code = request.form["code"]
        code.strip()
        result, error = run(code)
        if error:
            result = error

        return render_template("codeeditor.html", code=code, result=result)


# 归档
@bp.route("/archive")
def Archive():
    blogs = Blog.query.order_by(Blog.create_time.desc()).all()
    archive_dict = {}
    for blog in blogs:
        month = blog.create_time.strftime("%Y-%m")
        time = blog.create_time.strftime("%Y-%m-%d")
        if month not in archive_dict.keys():
            archive_dict[month] = []
        archive_dict[month].append((time, blog.blog_name))

    return render_template("timeline.html", archive_dict=archive_dict)


# 栏目简述
@bp.route("/section")
def Sections():
    sectionsinDB = Section.query.all()

    # 制作字典
    sections = []
    for section in sectionsinDB:
        # 描述栏目
        with open(f"./static/Introduction/{section.section_name}.md", "r", encoding="utf-8") as f:
            content = f.read()
        description_section = markdown.markdown(content)

        sections.append({
            "section_name": section.section_name,
            "description": description_section
        })

    return render_template("sections.html", sections=sections)


# 栏目中文章简述
@bp.route("/section/<section_name>")
def blogsInSection(section_name):
    section = Section.query.filter_by(section_name=section_name).first()

    blogsinDB = Blog.query.filter_by(sid=section.sid).all()

    # 描述栏目
    with open(f"./static/Introduction/{section_name}.md", "r", encoding="utf-8") as f:
        content = f.read()

    description_section = markdown.markdown(content)

    blogs = []

    # 制作blogs字典列表
    for blog in blogsinDB:
        # 通过名字找Description
        with open(blog.file_name, "r", encoding="utf-8") as f:
            content = f.read()
        md = markdown.Markdown(extensions=["meta"])
        html = md.convert(content)
        description_blog = md.Meta.get("description", "")[0]
        description_blog = f"<p>{description_blog}</p><br>"

        # concat
        blogs.append({
            "author": blog.author,
            "blog_name": blog.blog_name,
            "description": description_blog,
            "create_time": blog.create_time
        })

    return render_template("section.html", section=section, blogs=blogs, description=description_section)


# 文章展示
@bp.route("/blog/<filename>")
def blog(filename):
    # 获得blog对象
    blog = Blog.query.filter_by(blog_name=filename).first()
    path = blog.file_name
    title = blog.blog_name

    # 渲染左导航栏
    section = blog.section
    blogs = Blog.query.filter_by(sid=section.sid).all()

    with open(path, "r", encoding="utf-8") as f:
        content = f.read()

    # markdown to html
    md = markdown.Markdown(extensions=['fenced_code', "meta", "toc", "mdx_math", AttrListExtension()],
                           extension_configs={
                               'mdx_math': {
                                   'enable_dollar_delimiter': True,  # 是否启用单美元符号（默认只启用双美元）
                                   'add_preview': True  # 在公式加载成功前是否启用预览（默认不启用）
                               }
                           })
    html = md.convert(content)

    # 生成右导航
    table_of_content = md.toc

    # show
    return render_template("main.html", title=title, section_name=section.section_name,
                           blogs=blogs, content=html,
                           table_of_contents=table_of_content)
