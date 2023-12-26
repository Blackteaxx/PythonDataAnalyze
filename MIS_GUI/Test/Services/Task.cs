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
}