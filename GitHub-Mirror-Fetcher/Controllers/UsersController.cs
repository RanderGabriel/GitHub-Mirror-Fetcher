using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitHub_Mirror_Fetcher.Models;
using GitHub_Mirror_Fetcher.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GitHub_Mirror_Fetcher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public IUserRepository _userRepo;
        public UsersController()
        {
            _userRepo = new UserRepository();
        }
        //GET api/users
        [HttpGet]
        public IEnumerable<User> Get(int page = 0)
        {
            return _userRepo.GetUsers(page);
        }
        //GET api/users/{id}/projects
        [HttpGet("{id}/projects")]
        public IEnumerable<Project> GetProjectsForUser(int id)
        {
            return _userRepo.GetUserProjects(id);
        }
        // GET api/users/locations
        [HttpGet("locations")]
        public IEnumerable<string> GetLocations(int page = 0)
        {
            return _userRepo.GetLocations(page);
        }

    }
}
