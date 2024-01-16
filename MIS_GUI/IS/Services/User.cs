using IS.Services.DataBase;
using Microsoft.Data.SqlClient;
using System.Text.RegularExpressions;

namespace IS.Services;

public class User
{
    /// <summary>
    /// 注册新用户
    /// </summary>
    /// <param name="loginName"></param>
    /// <param name="password"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public ReturnValue Register(string loginName, string password, string name)
    {
        try
        {
            // 判断登录名是否合法
            if (loginName.Length > 20 || loginName.Length <= 0) return new ReturnValue("登录名不合法");

            //判断密码是否合格
            // 要求8位以上,20位以下，至少有数字，字母和符号中的两种
            if (password.Length > 20 || password.Length <= 0 ||
                !Regex.IsMatch(password, @"^(?![a-zA-Z]+$)(?!\d+$)(?![^\da-zA-Z\s]+$).{8,}$"))
                return new ReturnValue("密码不合法");

            //判断名字是否合法
            if (name.Length > 20 || name.Length <= 0) return new ReturnValue("名字不合法");

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
            if (e.Number == 2627) return new ReturnValue("登录 名重复"); // 登录名重复
        }

        return new ReturnValue(true, "注册成功", null);
    }

    /// <summary>
    ///     用户登录
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
        if (!r.HasRows) return new ReturnValue("登录名或密码错误");
        if (r.Read()) return new ReturnValue(true, r.GetInt32(0));
        return new ReturnValue("登录名或密码错误");
    }
    
    /// <summary>
    ///  通知结构体
    /// </summary>
    public struct NoticeItem
    {
        public int Nid { get; set; }
        public string Content { get; set; }
        public int Type { get; set; }
        public int Tid { get; set; }
    }

    public List<NoticeItem> GetUserNotices(int uid)
    {
        var result = new List<NoticeItem>();
        var reader = Sql.ExecuteReader(
            "SELECT Nid,NContent,NType,Nteam FROM UserNoticesView WHERE Uid = @uid and NStatus = 0",
            new Dictionary<string, object?>
            {
                { "uid", uid }
            }
        );
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                result.Add(new NoticeItem
                {
                    Nid = reader.GetInt32(0),
                    Content = reader.GetString(1),
                    Type = reader.GetInt32(2),
                    Tid = reader.IsDBNull(3) ? -1 : reader.GetInt32(3)
                });
            }
        }
        return  result;
    }

    /// <summary>
    /// 新增一条通知
    /// </summary>
    /// <param name="uid"></param>
    /// <param name="content"></param>
    /// <param name="type">0通知，1邀请</param>
    public void AddNotice(int uid, string content, int type)
    {
        Sql.ExecuteNonQuery(
            "INSERT INTO Notice(NContent,NType,NStatus) VALUES(@content,@type,0);" +
            "Insert into UserNotices(Nid,Uid) values(@@identity,@Uid);",
            new Dictionary<string, object?>
            {
                { "uid", 1 },
                { "content", "content" },
                { "type", 0 }
            }
        );
    }

    /// <summary>
    /// 新增一条团队邀请
    /// </summary>
    /// <param name="uid"></param>
    /// <param name="content"></param>
    /// <param name="type">0通知，1邀请</param>
    /// <param name="tid"></param>
    public void AddNotice(int uid, string content, int type,int tid)
    {
        Sql.ExecuteNonQuery(
            "INSERT INTO Notice(NContent,NType,NStatus) VALUES(@content,@type,0);" +
            "Insert into UserNotices(Nid,Uid) values(@@identity,@Uid);",
            new Dictionary<string, object?>
            {
                { "uid", 1 },
                { "content", "content" },
                { "type", 0 }
            }
        );
    }

    /// <summary>
    /// 将处理完的通知设置为已处理
    /// </summary>
    /// <param name="nid"></param>
    public void HandleNotice(int nid,int status)
    {
        Sql.ExecuteNonQuery(
            "UPDATE Notice SET NStatus = @status WHERE Nid = @nid;",
            new Dictionary<string, object?>
            {
                { "nid", nid },
                { "status", status },
            }
        ); 
    }
}