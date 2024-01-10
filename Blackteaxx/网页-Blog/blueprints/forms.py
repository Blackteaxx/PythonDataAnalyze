import wtforms
from wtforms.validators import Email, Length, EqualTo
from models import UserModel


# Form:验证前端提交的数据是否符合要求
class RegisterForm(wtforms.Form):
    # 根据input.name 获取数据
    email = wtforms.StringField(validators=
                                [Email(message="邮箱格式错误！")])
    username = wtforms.StringField(validators=
                                   [Length(min=3, max=20, message="用户名格式错误！")])
    password = wtforms.StringField(validators=
                                   [Length(min=6, max=20, message="密码格式错误！")])
    confirm_password = wtforms.StringField(validators=[Length(min=6, max=20, message="密码格式错误！"),
                                                       EqualTo("password", message="两次密码格式不一致")])

    # 自定义验证
    # 邮箱是否已被注册
    def validate_email(self, field):
        email = field.data
        user = UserModel.query.filter_by(email=email).first()
        if user:
            raise wtforms.ValidationError(message="该邮箱已被注册！")

    # 用户名是否已被注册
    def validate_username(self, field):
        username = field.data
        user = UserModel.query.filter_by(username=username).first()
        if user:
            raise wtforms.ValidationError(message="该用户名已被注册！")


class LoginForm(wtforms.Form):
    username = wtforms.StringField(validators=
                                   [Length(min=3, max=20, message="用户名格式错误！")])
    password = wtforms.StringField(validators=
                                   [Length(min=6, max=20, message="密码格式错误！")])
