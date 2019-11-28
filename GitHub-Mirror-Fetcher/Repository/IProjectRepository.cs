using GitHub_Mirror_Fetcher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHub_Mirror_Fetcher.Repository
{
    public interface IProjectRepository
    {
        IEnumerable<LanguageRank> GetTopLanguagesByYear(int year);
        IEnumerable<Project> GetProjects(int page); 
    }
}
