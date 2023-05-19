from flask import Flask
import config
from exts import db
from threading import Thread
from blueprints.blog import bp as blog_bp
from blueprints.author import bp as author_bp
from blueprints.admin import bp as admin_bp
from flask_migrate import Migrate
import utils

app = Flask(__name__)
# 绑定配置文件
app.config.from_object(config)

db.init_app(app)

# 配置数据库更新
migrate = Migrate(app, db)

# 定义蓝图：blueprint，用来做模块化
app.register_blueprint(blog_bp)
app.register_blueprint(author_bp)
app.register_blueprint(admin_bp)

# 自动化录入md
# thread = Thread(target=utils.save_sections_blogs, args=(3600,))
# thread.start()

if __name__ == '__main__':
    app.run()

