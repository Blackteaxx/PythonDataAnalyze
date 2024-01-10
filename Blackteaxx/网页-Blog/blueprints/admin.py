from flask import Blueprint, render_template

# /auth
bp = Blueprint("admin", __name__, url_prefix="/admin")


@bp.route('/')
def index():
    return render_template("index.html")
