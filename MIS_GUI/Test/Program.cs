// See https://aka.ms/new-console-template for more information

using IS.Services;
using Microsoft.IdentityModel.Tokens;

var u = new User();
var t = new Team();
var task = new IS.Services.Task();
// Console.WriteLine(u.Register("test", "123", "123"));
// Console.WriteLine(u.Login("123","123"));
// Console.WriteLine(t.CreateTeam(1,"1", "test"));
// Console.WriteLine(t.CreateTeam(1,"2", "test"));
// Console.WriteLine(t.CreateTeam(1,"3", "test"));
Console.WriteLine(t.CreateTeam(1,"5", "test"));
// Console.WriteLine(t.JoinTeam(7,1));
// Console.WriteLine(t.GetTeams(1));
// Console.WriteLine(t.JoinTeam(1,"930649FEB"));
// var r = t.GetTeamInfo(1);
// var r = t.SearchTeams("1");
// Console.WriteLine(task.CreateTask(1, 1, "test", "test"));
// Console.WriteLine("");