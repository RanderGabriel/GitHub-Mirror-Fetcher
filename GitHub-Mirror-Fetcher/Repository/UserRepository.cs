using Dapper;
using GitHub_Mirror_Fetcher.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHub_Mirror_Fetcher.Repository
{
    public class UserRepository : IUserRepository
    {
        public MySqlConnection sqlConnection = new MySqlConnection("Server=127.0.0.1; Uid=****; Pwd=************ ;Database=ghtorrent_restore;");
        
        public IEnumerable<string> GetLocations(int page)
        {
            sqlConnection.Open();
            var query = sqlConnection.Query<string>($"SELECT DISTINCT(location) FROM users LIMIT {page*100}, 100;");
            return query;
        }

        public IEnumerable<User> GetUsers(int page)
        {
            sqlConnection.Open();
            var query = sqlConnection.Query<User>($"SELECT * FROM users LIMIT {page * 100}, 100");
            return query;
        }

        public IEnumerable<Project> GetUserProjects(int userId)
        {
            sqlConnection.Open();
            var query = sqlConnection.Query<Project>($"SELECT * FROM projects WHERE owner_id = {userId}");
            return query;
        }
    }
}
