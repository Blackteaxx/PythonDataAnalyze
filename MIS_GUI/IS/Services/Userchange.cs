using IS.Services.DataBase;
using Microsoft.Data.SqlClient;
using System.Text.RegularExpressions;

namespace IS.Services;

public class UserChange
{
    public ReturnValue ChangeName(string loginName,string password,string oldname,string newname)
    {
        if (newname.Length > 20 || newname.Length <= 0) return new ReturnValue("名字不合法");
        var r = Sql.ExecuteNonQuery(
                "UPDATE [USER] SET Name = @newname WHERE loginName = @loginName AND password = @password",
                new Dictionary<string, object?>
                {
                    { "loginName", loginName },
                    { "password", password },
                    { "name", newname }
                }
            );
        return new ReturnValue(true, "修改名字成功", null);

    }
    public ReturnValue ChangeLoginName(string loginName, string password, string newloginName)
    {
        if (loginName.Length > 20 || loginName.Length <= 0) return new ReturnValue("登录名不合法");
        var r = Sql.ExecuteNonQuery(
                "UPDATE [USER] SET LoginName = @newloginName WHERE loginName = @loginName AND password = @password",
                new Dictionary<string, object?>
                {
                    { "loginName", loginName },
                    { "password", password },
                    { "name", newloginName }
                }
            );
        return new ReturnValue(true, "修改登录名成功", null);

    }
    public ReturnValue ChangePassword(string loginName, string password, string newpassword)
    {
        if (newpassword == password) return new ReturnValue("新密码不能和旧密码一致");
        if (password.Length > 20 || password.Length <= 0 ||
                !Regex.IsMatch(password, @"^(?![a-zA-Z]+$)(?!\d+$)(?![^\da-zA-Z\s]+$).{8,}$"))
            return new ReturnValue("密码不合法");
        var r = Sql.ExecuteNonQuery(
                "UPDATE [USER] SET Password = @newpassword WHERE loginName = @loginName AND password = @password",
                new Dictionary<string, object?>
                {
                    { "loginName", loginName },
                    { "password", password },
                    { "name", newpassword }
                }
            );
        return new ReturnValue(true, "修改登录名成功", null);

    }
}