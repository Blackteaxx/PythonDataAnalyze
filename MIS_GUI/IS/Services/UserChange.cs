using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS.Services.DataBase;
namespace UserInfo
{
    public class UserChange
    {
        public struct UserInfo
        {
            public int uid;
            public string loginName;
            public string password;
            public string Name;
        };
        public UserInfo GetUserInfo(int uid)
        {
            var reader = Sql.ExecuteReader("SELECT Uid,loginName,Password,Name FROM [USER] WHERE Uid = @uid",
                new Dictionary<string, object?>
                {
                { "uid", uid }
                }
                );
            reader.Read();
            return new UserInfo
            {
                uid = uid,
                loginName = reader.GetString(0),
                password = reader.GetString(1),
                Name = reader.GetString(2)
            };
        }

        public string UpdateUserInfo(int uid,string loginName, string Password,string Name)
        {
            try
            {
                var r = Sql.ExecuteReader(
                "UPDATE USER SET loginName = @loginName,Password = @Password, Name = @Name WHERE Uid=@uid",
                 new Dictionary<string, object?>
                {
                     { "@uid", uid },
                     { "@loginName", loginName },
                     { "@Password", Password },
                     { "@Name", Name }
                }
             );
                return ("ok");
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            
        }
        

    }
    

   
}
