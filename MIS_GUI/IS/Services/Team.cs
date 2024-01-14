using System.Text.RegularExpressions;
using IS.Services.DataBase;

namespace IS.Services;

public class Team
{
    /// <summary>
    /// 创建团队
    /// </summary>
    /// <param name="name">团队的名字</param>
    /// <param name="description">团队的介绍</param>
    /// <returns></returns>
    public string CreateTeam(int uid, string name, string description)
    {
        try
        {
            // 先对参数进行合法性检验
            if (name.Length > 20 || name.Length <= 0) return "名字不合法";
            if (description.Length > 140 || description.Length <= 0) return "介绍不合法";

            string joinCode;
            while (true)
            {
                // 自动生成加入码
                joinCode = Guid.NewGuid().ToString("N").Substring(8, 9).ToUpper();
                // 检查加入码是否重复
                var r = Sql.ExecuteNonQuery(
                    "Select count(*) from Team where joinCode = @joinCode",
                    new Dictionary<string, object?>
                    {
                        { "joinCode", joinCode }
                    }
                );
                if (r < 1) break; // 不存在重复则跳出
            }

            // 插入团队信息
            var r1 = Sql.ExecuteNonQuery(
                @"EXEC CreateTeam @uid, @name, @description, @joinCode",
                new Dictionary<string, object?>
                {
                    { "@name", name },
                    { "@uid", uid },
                    { "@description", description },
                    { "@joinCode", joinCode }
                }
            );
            return "";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    /// <summary>
    /// 创建团队
    /// </summary>
    /// <param name="name">团队的名字</param>
    /// <param name="description">团队的介绍</param>
    /// <param name="joinCode">团队的加入码</param>
    /// <returns></returns>
    public string CreateTeam(int uid, string name, string description, string joinCode)
    {
        try
        {
            // 先对参数进行合法性检验
            if (name.Length > 20 || name.Length <= 0) return "名字不合法";
            if (description.Length > 140 || description.Length <= 0) return "介绍不合法";

            var r = Sql.ExecuteNonQuery(
                "Select count(*) from Team where joinCode = @joinCode",
                new Dictionary<string, object?>
                {
                    { "joinCode", joinCode }
                }
            );
            if (r == 1) return "加入码已存在，请重新输入。"; // 不存在重复则跳出

            // 插入团队信息
            var r1 = Sql.ExecuteNonQuery(
                @"EXEC CreateTeam @uid, @name, @description, @joinCode",
                new Dictionary<string, object?>
                {
                    { "@name", name },
                    { "@uid", uid },
                    { "@description", description },
                    { "@joinCode", joinCode }
                }
            );
            return "";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    /// <summary>
    /// 获取团队
    /// </summary>
    /// <param name="uid">用户的uid</param>
    /// <returns></returns>
    public List<List<string>>? GetTeams(int uid)
    {
        var reader = Sql.ExecuteReader(
            "SELECT Tid,Name,Description,PeopleNumber,Role FROM UserTeamsView WHERE Uid = @uid and Role != 'Delete'",
            new Dictionary<string, object?>
            {
                { "uid", uid }
            }
        );
        if (!reader.HasRows) return null;

        var result = new List<List<string>>();
        while (reader.Read())
            result.Add(new List<string>
            {
                reader.GetInt32(0).ToString(), // tid
                reader.GetString(1), // name
                reader.GetString(2), //描述
                reader.GetInt32(3).ToString(), // 人数
                reader.GetString(4) // 角色
            });
        return result;
    }

    public int GetTeamId(string teamName)
    {
        var reader = Sql.ExecuteReader(
                       "SELECT Tid FROM Team WHERE Name = @teamName",
                                  new Dictionary<string, object?>
                                  {
                { "teamName", teamName }
            }
                                         );
        reader.Read();
        return reader.GetInt32(0);
    }

    public string? UpdateTeamInfo(int tid, string name, string description, int joinRight, int joinCodeRight)
    {
        try
        {
            var r = Sql.ExecuteNonQuery(
                "UPDATE Team SET Name = @name,Description = @description,JoinRight = @joinRight,JoinCodeRight = @joinCodeRight WHERE Tid = @tid",
                new Dictionary<string, object?>
                {
                    { "@tid", tid },
                    { "@name", name },
                    { "@description", description },
                    { "@joinRight", joinRight },
                    { "@joinCodeRight", joinCodeRight }
                }
            );
            return "ok";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    /// <summary>
    /// 获取该团队的全部成员信息
    /// </summary>
    /// <param name="tid"></param>
    /// <returns></returns>
    public List<List<string>> GetTeamMembers(int tid)
    {
        var reader = Sql.ExecuteReader(
            "SELECT Uid,Name,Role FROM TeamMemberView WHERE Tid = @tid",
            new Dictionary<string, object?>
            {
                { "tid", tid }
            }
        );
        var result = new List<List<string>>();
        while (reader.Read())
            result.Add(new List<string>
            {
                reader.GetInt32(0).ToString(),
                reader.GetString(1),
                reader.GetString(2)
            });
        return result;
    }

    /// <summary>
    /// 团队信息
    /// </summary>
    public struct TeamInfo
    {
        public int tid;
        public string name;
        public string description;
        public int peoplenumber;
        public string joinCode;
        public int uid;
        public string username;
        public int joinRight;
        public int joinCodeRight;
    }

    /// <summary>
    /// 获取团队的具体信息
    /// </summary>
    /// <param name="tid"></param>
    /// <returns></returns>
    public TeamInfo GetTeamInfo(int tid)
    {
        var reader = Sql.ExecuteReader(
            "EXEC GetTeamInfo @tid",
            new Dictionary<string, object?>
            {
                { "tid", tid }
            }
        );
        reader.Read();
        return new TeamInfo
        {
            tid = tid,
            name = reader.GetString(0),
            description = reader.GetString(1),
            peoplenumber = reader.GetInt32(2),
            joinCode = reader.GetString(3),
            uid = reader.GetInt32(4),
            username = reader.GetString(5),
            joinRight = reader.GetInt32(6),
            joinCodeRight = reader.GetInt32(7)
        };
    }

    /// <summary>
    /// 团队成员信息
    /// </summary>
    public struct TeamMember
    {
        public int uid;
        public string name;
        public string role;
    }


    // 获取团队的成员信息，以uid，name和role的形式返回
    public List<TeamMember> GetTeamMembersInfo(int tid)
    {
        var reader = Sql.ExecuteReader(
            "SELECT Uid,Name,Role FROM TeamMemberView WHERE Tid = @tid",
            new Dictionary<string, object?>
            {
                { "tid", tid }
            }
        );
        var result = new List<TeamMember>();
        while (reader.Read())
            result.Add(new TeamMember
            {
                uid = reader.GetInt32(0),
                name = reader.GetString(1),
                role = reader.GetString(2)
            });
        return result;
    }

    /// <summary>
    /// 通过团队的Uid来加入团队
    /// </summary>
    /// <param name="uid"></param>
    /// <param name="tid"></param>
    /// <returns></returns>
    public string JoinTeam(int uid, int tid)
    {
        try
        {
            var r = Sql.ExecuteNonQuery(
                "Insert into TeamMember (Tid,Uid,Role) values (@tid, @uid ,'Member')",
                new Dictionary<string, object?>
                {
                    { "tid", tid },
                    { "uid", uid }
                }
            );
            return "加入成功";
        }
        catch (Exception e)
        {
            return "加入失败";
        }
    }

    /// <summary>
    /// 根据加入码来加入对应的团队
    /// </summary>
    /// <param name="uid"></param>
    /// <param name="joinCode"></param>
    /// <returns></returns>
    public ReturnValue JoinTeam(int uid, string joinCode)
    {
        try
        {
            //  先判断是否存在该加入码的团队
            var tid = Sql.ExecuteScalar(
                "Select Tid from Team where joinCode = @joinCode",
                new Dictionary<string, object?>
                {
                    { "joinCode", joinCode }
                }
            );

            if (tid is null) // 如果为空，则说明不存在
                return new ReturnValue(false, "不存在该加入码的团队", null);

            var r = Sql.ExecuteNonQuery(
                "Insert into TeamMember (Tid,Uid,Role) values (@tid, @uid ,'Member')",
                new Dictionary<string, object?>
                {
                    { "tid", Convert.ToInt32(tid) },
                    { "uid", uid }
                }
            );
            return new ReturnValue(true, "加入成功", null);
        }
        catch (Exception e)
        {
            return new ReturnValue(false, "加入失败", e.Message);
        }
    }

    // 用户退出团队
    /// <summary>
    /// 用户退出团队，自动判断是否会解散团队
    /// </summary>
    /// <param name="tid"></param>
    /// <param name="uid"></param>
    /// <returns></returns>
    public string QuitTeam(int tid, int uid)
    {
        try
        {
            var r = Sql.ExecuteNonQuery(
                "EXEC QuitTeam @tid ,@uid;",
                new Dictionary<string, object?>
                {
                    { "tid", tid },
                    { "uid", uid }
                }
            );
            return "成功退出";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public struct SearchTeamItem
    {
        public int Tid;
        public string Name;
        public string Description;
    }

    /// <summary>
    /// 搜索满足条件的团队
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public List<SearchTeamItem> SearchTeam(string s)
    {
        // 先判断是不是加入码
        string pattern = @"^[A-Z0-9]{9}$";
        var result = new List<SearchTeamItem>();
        if (Regex.IsMatch(s, pattern))
        {
            var r1 = Sql.ExecuteReader(
                "SELECT Tid,Name,Description FROM Team WHERE JoinCode = @joinCode",
                new Dictionary<string, object?>
                    {
                        { "joinCode", s }
                    }
                );
            if (r1.HasRows)
                while (r1.Read())
                {
                    result.Add(new SearchTeamItem
                    {
                        Tid = r1.GetInt32(0),
                        Name = r1.GetString(1),
                        Description = r1.GetString(2)
                    });
                }
        }
        // 不管是不是加入码，都要按照名字搜索一下

        var r2 = Sql.ExecuteReader(
            "SELECT Tid,Name,Description FROM Team WHERE Name like @name",
            new Dictionary<string, object?>
                {
                    { "name", "%" + s + "%" }
                }
            );
        if (r2.HasRows)
            while (r2.Read())
            {
                result.Add(new SearchTeamItem
                {
                    Tid = r2.GetInt32(0),
                    Name = r2.GetString(1),
                    Description = r2.GetString(2)
                });
            }
        return result;
    }

    // 设置用户的身份为管理员
    /// <summary>
    /// 设置用户的身份为管理员
    /// </summary>
    /// <param name="tid"></param>
    /// <param name="uid"></param>
    /// <returns></returns>
    public string SetAdmin(int tid, int uid)
    {
        try
        {
            var r = Sql.ExecuteNonQuery(
                "UPDATE TeamMember SET Role = 'Admin' WHERE Tid = @tid and Uid = @uid",
                new Dictionary<string, object?>
                {
                    { "uid", uid },
                    { "tid", tid }
                }
            );
            return "设置成功";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    // 设置用户的身份为普通成员
    /// <summary>
    /// 设置用户的身份为普通成员
    /// </summary>
    /// <param name="tid"></param>
    /// <param name="uid"></param>
    /// <returns></returns>
    public string SetMember(int tid, int uid)
    {
        try
        {
            var r = Sql.ExecuteNonQuery(
                "UPDATE TeamMember SET Role = 'Member' WHERE Tid = @tid and Uid = @uid",
                new Dictionary<string, object?>
                {
                    { "uid", uid },
                    { "tid", tid }
                }
            );
            return "设置成功";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    // 设置成员为所有者，同时自己降级为管理员
    /// <summary>
    /// 设置成员为所有者，同时自己降级为管理员
    /// </summary>
    /// <param name="tid"></param>
    /// <param name="uid"></param>
    /// <returns></returns>
    public string SetOwner(int tid, int memverUid, int OwnerUid)
    {
        try
        {
            var r = Sql.ExecuteNonQuery(
                "UPDATE TeamMember SET Role = 'Owner' WHERE Tid = @tid and Uid = @memverUid;" +
                "UPDATE TeamMember SET Role = 'Admin' WHERE Tid = @tid and Uid = @OwnerUid;",
                new Dictionary<string, object?>
                {
                    { "memverUid", memverUid },
                    { "tid", tid },
                    { "OwnerUid" , OwnerUid }
                }
            );
            return "设置成功";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public struct TeamTaskItem
    {
        public  int Taskid;
        public  string Name;
        public  string Description;
        public  string MasterName;
        public int Status;
    }

    public List<TeamTaskItem> GetTeamTasks(int tid)
    {
        var result = new List<TeamTaskItem>();
        var r = Sql.ExecuteReader(
            "SELECT TaskId, Name, Description,MasterName,Status FROM TeamTaskView WHERE TeamId = @tid",
            new Dictionary<string, object?>
            {
                { "tid", tid }
            }
        );
        if (r.HasRows)
            while (r.Read())
            {
                result.Add(new TeamTaskItem
                {
                    Taskid = r.GetInt32(0),
                    Name = r.GetString(1),
                    Description = r.GetString(2),
                    MasterName = r.GetString(3),
                    Status = r.GetInt32(4),
                });
            }
        return result;
    }

    /// <summary>
    /// 获取用户在该团队内参与的任务
    /// </summary>
    /// <param name="uid"></param>
    /// <param name="tid"></param>
    /// <returns></returns>
    public List<int> GetTasksParticipating(int uid, int tid)
    {
        var result = new List<int>();
        var r = Sql.ExecuteReader(
            "SELECT TaskId FROM TeamTasks WHERE TeamId = @tid " +
            "and EXISTS(SELECT * FROM TaskMember WHERE Tid = TaskId and Uid = @uid)",
            new Dictionary<string, object?>
            {
                { "tid", tid },
                { "uid", uid }
            }
        );
        if (r.HasRows)
            while (r.Read())
            {
                result.Add(r.GetInt32(0));
            }
        return result;
    }
}