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
        public MySqlConnection sqlConnection = new MySqlConnection("Server=127.0.0.1; Port=3307; Uid=root; Pwd=rootpassword ;Database=ghtorrent_restore;");
        
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

        public IEnumerable<Project> GetUserProjects(string login)
        {
            sqlConnection.Open();
            var query = sqlConnection.Query<Project>($"SELECT p.* FROM projects p INNER JOIN users u ON u.id = p.owner_id WHERE login = '{login}'");
            return query;
        }

        public User GetByLogin(string login)
        {
            sqlConnection.Open();
            var query = sqlConnection.Query<User>($"SELECT * FROM users WHERE login = '{login}'");
            return query.FirstOrDefault();
        }

        public IEnumerable<Stats> GetUserStats()
        {
            sqlConnection.Open();
            var command = sqlConnection.CreateCommand();
            command.CommandTimeout = 10000;
            string queryString = $@"select count(*) as 'amount', SUBSTRING(created_at, 1, 7) as 'month_year' from projects where (created_at > '2010' and created_at < '2015')
                                    group by SUBSTRING(created_at, 1, 7);";

            command.CommandText = queryString;
            MySqlDataReader reader = command.ExecuteReader();
            List<Stats> query = new List<Stats>();
            while (reader.Read())
            {
                Stats lr = new Stats();
                lr.amount = reader["amount"].ToString();
                lr.month_year = reader["month_year"].ToString();
                query.Add(lr);
            }
            sqlConnection.Close();
            return query;
        }
    }
}
