using GitHub_Mirror_Fetcher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHub_Mirror_Fetcher.Repository
{
    public interface IUserRepository
    {
        IEnumerable<string> GetLocations(int page);
        IEnumerable<Project> GetUserProjects(int userId);
        IEnumerable<User> GetUsers(int page);
        User GetByLogin(string login);
    }
}
