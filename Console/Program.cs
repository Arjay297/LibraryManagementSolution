


//LinQ - Done
//List - Done
//Results - Done
//Ef Core - Done
//Migrations 
using Consolesdfsdf;
using System.Text.Json;
List<User> users = [
            new User(){Id = 1, Name = "Stephen"},
            new User(){Id = 2, Name = "Boy"},
            new User(){Id = 3, Name = "Irvin"},
            new User(){Id = 4, Name = "Arjay"},
            ];

var find = users
    .LastOrDefault();

string json = JsonSerializer.Serialize(find);

Console.Write(json);