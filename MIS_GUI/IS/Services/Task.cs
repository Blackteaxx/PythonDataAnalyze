using IS.Services.DataBase;

namespace IS.Services;

public class Task
{
    /// <summary>
    ///     在给定的团队下创建对应的项目
    /// </summary>
    /// <param name="teamId"></param>
    /// <param name="uid"></param>
    /// <param name="name"></param>
    /// <param name="description"></param>
    /// <returns>如果成功则返回null</returns>
    public string? CreateTask(int teamId, int uid, string name, string description)
    {
        try
        {
            var r = Sql.ExecuteNonQuery(
                "EXEC CreateTask @teamId,@uid,@name,@description",
                new Dictionary<string, object?>
                {
                    { "@teamId", teamId },
                    { "@uid", uid },
                    { "@name", name },
                    { "@description", description }
                }
            );
            return null;
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    /// <summary>
    /// 获取任务
    /// </summary>
    /// <param name="uid">用户的uid</param>
    /// <returns></returns>
    public List<List<string>>? GetTasks(int uid)
    {
        var reader = Sql.ExecuteReader(
            "SELECT Tid,TaskName,TeamName,PeopleNumber FROM TaskTeamView WHERE Uid = @uid",
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
                reader.GetString(1), // TaskName
                reader.GetString(2), //TeamName
                reader.GetInt32(3).ToString(), // 人数
            });
        return result;
    }


    /// <summary>
    /// 根据tid获取任务信息
    /// </summary>
    /// <param name="tid"></param>
    /// <return></return>
    public List<string>? GetTask(int tid)
    {
        var reader = Sql.ExecuteReader(
                       "SELECT Name, Description, PeopleNumber FROM Task WHERE Tid = @tid",
                                  new Dictionary<string, object?>
                                  {
                { "tid", tid }
            }
                                         );
        if (!reader.HasRows) return null;

        reader.Read();
        var result = new List<string>
        {           
            reader.GetString(0), // TaskName
            reader.GetString(1), //Description
            reader.GetInt32(2).ToString(), // 人数
        };
        return result;
    }


    public int GetTeamId(int tid)
    {
        // 根据taskid获取teamid
#pragma warning disable CS8605 // 取消装箱可能为 null 的值。
        return
            (int)Sql.ExecuteScalar(
                       "SELECT * FROM TeamTasks WHERE TaskId = @tid",
            new Dictionary<string, object?>
            {
                { "tid", tid }
            }
                                         );
#pragma warning restore CS8605 // 取消装箱可能为 null 的值。

    }

    public List<string>? GetTaskMembers(int tid)
    {
        // 根据tid获取所有成员信息
        var reader = Sql.ExecuteReader(
                       "SELECT Name, [User].UID FROM TaskMember, [User] WHERE [User].UID = TaskMember.UID and Tid = @tid",
                                  new Dictionary<string, object?>
                                  {
                { "tid", tid }
            }
                                         );
        if (!reader.HasRows) return null;

        var result = new List<string>();
        while (reader.Read())
            result.Add(reader.GetString(0));
        return result;
    }
}