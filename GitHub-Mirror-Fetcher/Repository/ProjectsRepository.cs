using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using GitHub_Mirror_Fetcher.Models;
using MySql.Data.MySqlClient;

namespace GitHub_Mirror_Fetcher.Repository
{
    public class ProjectsRepository : IProjectRepository
    {
        public MySqlConnection sqlConnection = new MySqlConnection("Server=127.0.0.1;Port=3307; Uid=root; Pwd=rootpassword ;Database=ghtorrent_restore;Connect Timeout=300");

        public IEnumerable<Project> GetProjects(int page)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LanguageRank> GetTopLanguagesByYear(int year)
        {
            sqlConnection.Open();
            var command = sqlConnection.CreateCommand();
            command.CommandTimeout = 10000;
            string queryString = $@"SELECT COUNT(*) as 'count', language FROM projects WHERE created_at like '{year}-%' AND language IS NOT NULL
                                    GROUP BY language
                                    ORDER BY COUNT(*) DESC
                                    LIMIT 10;";

            command.CommandText = queryString;
            MySqlDataReader reader = command.ExecuteReader();
            List<LanguageRank> query = new List<LanguageRank>();
            while(reader.Read())
            {
                LanguageRank lr = new LanguageRank();
                lr.language = reader["language"].ToString();
                lr.projects_count = int.Parse(reader["count"].ToString());
                query.Add(lr);
            }
            sqlConnection.Close();
            //var query = sqlConnection.Query<LanguageRank>(queryString);
            return query;
        }
    }
}
