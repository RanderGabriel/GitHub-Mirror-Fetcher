using Dapper;
using GitHub_Mirror_Fetcher.Models;
using GitHub_Mirror_Fetcher.Repository;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GitHub_Mirror_Fetcher.Repository
{
    public class StudentRepository : IStudentRepository
    {
        //public MySqlConnection sqlConnection = new MySqlConnection("Server=IPDAMAQUINA; Uid=USUARIO; Pwd=SENHA ;Database=test;");

        public MySqlConnection sqlConnection = new MySqlConnection("Server=34.238.220.208; Uid=sa; Pwd=testando ;Database=test;");
        
        public IEnumerable<Student> getAll()
        {
            sqlConnection.Open();
            var query = sqlConnection.Query<Student>("SELECT * FROM aluno;");
            return query;
        }
    }
}
