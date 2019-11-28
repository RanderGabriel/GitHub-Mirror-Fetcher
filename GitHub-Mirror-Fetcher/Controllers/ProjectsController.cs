using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitHub_Mirror_Fetcher.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GitHub_Mirror_Fetcher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        public IProjectRepository _projectRepository;

        public ProjectsController()
        {
            _projectRepository = new ProjectsRepository();
        }

        //GET api/users/{id}/projects
        [HttpGet("languagesRank")]
        public IEnumerable<LanguageRank> GetLanguagesRank(int year)
        {
            return _projectRepository.GetTopLanguagesByYear(year);
        }
    }
}