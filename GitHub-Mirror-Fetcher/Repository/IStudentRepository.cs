using GitHub_Mirror_Fetcher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHub_Mirror_Fetcher.Repository
{
    interface IStudentRepository
    {
        IEnumerable<Student> getAll();
    }
}
