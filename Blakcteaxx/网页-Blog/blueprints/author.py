from flask import Blueprint, render_template, request, redirect, url_for, session, flash
from .forms import RegisterForm, LoginForm
from models import UserModel
from exts import db

# /auth
bp = Blueprint("author", __name__, url_prefix="/author")


def flasherror(formerrors):
    error = ""
    for value in formerrors.values():
        error = error + value[0] + "/ "
    return error[:-2]


@bp.route("/login", methods=['GET', 'POST'])
def login():
    if request.method == 'GET':
        return render_template("login.html")
    else:
        form = LoginForm(request.form)
        if form.validate():
            username = form.username.data
            password = form.password.data

            # 查询用户
            user = UserModel.query.filter_by(username=username).first()
            if not user:
                error = "用户不存在"
                # return redirect(url_for("author.login"))
            elif user.password != password:
                error = "用户密码错误"
                # return redirect(url_for("author.login"))
            else:
                # cookie
                # cookie中不适合存储太多的数据
                # cookie存放登录授权的东西
                # flask中的session，是经过加密存储在cookie中的
                session['user_id'] = user.uid
                return redirect("/")

            # 出现错误弹到此处
            flash(error)
            return redirect(url_for("author.login"))
        else:
            print(form.errors)
            flash(flasherror(form.errors))
            return redirect(url_for("author.login"))


# GET:从服务器上获取数据
# POST:将客户端数据提交给服务器
@bp.route('/register', methods=['GET', 'POST'])
def register():
    if request.method == 'GET':
        return render_template("register.html")
    else:
        # 表单验证:flask-wtf
        form = RegisterForm(request.form)
        if form.validate():
            email = form.email.data
            username = form.username.data
            password = form.password.data
            # 加密
            user = UserModel(username=username, password=password, email=email)
            db.session.add(user)
            db.session.commit()
            return redirect(url_for("author.login"))
        else:
            print(form.errors)
            flash(flasherror(form.errors))
            return redirect(url_for("author.register"))
