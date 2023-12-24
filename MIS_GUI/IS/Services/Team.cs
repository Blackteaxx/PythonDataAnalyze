using IS.Services.DataBase;

namespace IS.Services;

public class Team
{
    /// <summary>
    /// 创建团队
    /// </summary>
    /// <param name="name">团队的名字</param>
    /// <param name="uid">创建团队的人的uid</param>
    /// <param name="description">团队的介绍</param>
    /// <returns></returns>
    public ReturnValue CreateTeam(string name,int uid,string description)
    {
        try
        {
            // 先对参数进行合法性检验
            if (name.Length > 20 || name.Length <= 0)
            {
                return new ReturnValue("名字不合法");
            }
            if (description.Length > 120 || description.Length <= 0)
            {
                return new ReturnValue("介绍不合法");
            }

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
            return new ReturnValue(true, "创建成功",null);
        }
        catch (Exception e)
        {
            return new ReturnValue(e.Message);
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
            "SELECT Tid,Name,Description,PeopleNumber FROM UserTeamsView WHERE Uid = @uid",
            new Dictionary<string, object?>
            {
                { "uid", uid }
            }
        );
        if (!reader.HasRows)
        {
            return null;
        }

        List<List<string>> result = new List<List<string>>();
        while (reader.Read())
        {
            result.Add(new List<string>
            {
                reader.GetInt32(0).ToString(),
                reader.GetString(1),
                reader.GetString(2),
                reader.GetInt32(3).ToString()
            });
        }
        return result;
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
        List<List<string>> result = new List<List<string>>();
        while (reader.Read())
        {
            result.Add(new List<string>
            {
                reader.GetInt32(0).ToString(),
                reader.GetString(1),
                reader.GetString(2)
            });
        }
        return result;
    }

    /// <summary>
    /// 获取团队的具体信息
    /// </summary>
    /// <param name="tid"></param>
    /// <returns></returns>
    public List<string>? GetTeamInfo(int tid)
    {
        var reader = Sql.ExecuteReader(
            "EXEC GetTeamInfo @tid",
            new Dictionary<string, object?>
            {
                { "tid", tid }
            }
        );
        if (!reader.HasRows)
        {
            return null;
        }
        reader.Read();
        return new List<string>
        {
            reader.GetString(0),
            reader.GetString(1),
            reader.GetInt32(2).ToString(),
            reader.GetString(3),
            reader.GetInt32(4).ToString(),
            reader.GetString(5)
        };
    }

    /// <summary>
    /// 根据用户输入的搜索词查找名字相似的团队
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public List<List<string>> SearchTeams(string name)
    {
        var reader = Sql.ExecuteReader(
            "SELECT Tid,Name,Description,PeopleNumber FROM UserTeamsView WHERE Name like @name",
            new Dictionary<string, object?>
            {
                { "name", "%" + name + "%" }
            }
        );
        List<List<string>> result = new List<List<string>>();
        while (reader.Read())
        {
            result.Add(new List<string>
            {
                reader.GetInt32(0).ToString(),
                reader.GetString(1),
                reader.GetString(2),
                reader.GetInt32(3).ToString()
            });
        }
        
        // 把搜索结果按照相似度来排序,依据最小编辑距离
        return result;
    }
    
    /// <summary>
    /// 通过团队的Uid来加入团队
    /// </summary>
    /// <param name="uid"></param>
    /// <param name="tid"></param>
    /// <returns></returns>
    public ReturnValue JoinTeam(int uid,int tid)
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
            return new ReturnValue(true, "加入成功",null);
        }
        catch (Exception e)
        {
            return new ReturnValue(false, "加入失败",e.Message);
        }
    }

    /// <summary>
    /// 根据加入码来加入对应的团队
    /// </summary>
    /// <param name="uid"></param>
    /// <param name="joinCode"></param>
    /// <returns></returns>
    public ReturnValue JoinTeam(int uid,string joinCode)
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
            {
                return new ReturnValue(false, "不存在该加入码的团队",null);
            }
            
            var r = Sql.ExecuteNonQuery(
                "Insert into TeamMember (Tid,Uid,Role) values (@tid, @uid ,'Member')",
                new Dictionary<string, object?>
                {
                    { "tid", Convert.ToInt32(tid) },
                    { "uid", uid }
                }
            );
            return new ReturnValue(true, "加入成功",null);
        }
        catch (Exception e)
        {
            return new ReturnValue(false, "加入失败",e.Message);
        }
    }
}