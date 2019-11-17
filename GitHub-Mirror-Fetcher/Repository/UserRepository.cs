using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHub_Mirror_Fetcher.Repository
{
    public class UserRepository : IUserRepository
    {
        public MySqlConnection sqlConnection = new MySqlConnection("Server=127.0.0.1; Uid=root; Pwd=******* ;Database=ghtorrent_restore;");
        
        public IEnumerable<string> getAllLocations()
        {
            sqlConnection.Open();
            var query = sqlConnection.Query<string>("SELECT distinct(location) FROM users LIMIT 100;");
            return query;
        }
    }
}
