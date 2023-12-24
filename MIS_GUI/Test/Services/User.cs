using System.Text.RegularExpressions;
using IS.Services.DataBase;
using Microsoft.Data.SqlClient;

namespace IS.Services;

public class User
{
    public ReturnValue Register(string loginName, string password ,string name)
    {
        try
        {
            // 判断登录名是否合法
            if (loginName.Length > 20 || loginName.Length <= 0)
            {
                return new ReturnValue("登录名不合法");
            }
            
            //判断密码是否合格
            // 要求8位以上,20位以下，至少有数字，字母和符号中的两种
            if (password.Length > 20 || password.Length <= 0 || !Regex.IsMatch(password, @"^(?![a-zA-Z]+$)(?!\d+$)(?![^\da-zA-Z\s]+$).{8,}$"))
            {
                return new ReturnValue("密码不合法");
            }
            
            //判断名字是否合法
            if (name.Length > 20 || name.Length <= 0)
            {
                return new ReturnValue("名字不合法");
            }

            var r = Sql.ExecuteNonQuery(
                "INSERT INTO [USER](loginName,password,name) VALUES(@loginName,@password,@name)",
                new Dictionary<string, object?>
                {
                    { "loginName", loginName },
                    { "password", password },
                    { "name", name }
                }
            );
        }
        catch (SqlException e)
        {
            if (e.Number == 2627)
            {
                return new ReturnValue("登录 名重复"); // 登录名重复
            }
        }
        return new ReturnValue (true,"注册成功",null);
    }
    
    /// <summary>
    /// 用户登录
    /// </summary>
    /// <param name="loginName">登录名</param>
    /// <param name="password">密码</param>
    /// <returns></returns>
    public ReturnValue Login(string loginName, string password)
    {
        using var r = Sql.ExecuteReader(
            "SELECT Uid,Name FROM [USER] WHERE loginName = @loginName AND password = @password",
            new Dictionary<string, object?>
            {
                { "loginName", loginName },
                { "password", password }
            }
        );
        if (!r.HasRows)
        {
            return new ReturnValue("登录名或密码错误");
        }
        if (r.Read())
        {
            return new ReturnValue(true,r.GetInt32(0));
        }
        return new ReturnValue("登录名或密码错误");
    }
}