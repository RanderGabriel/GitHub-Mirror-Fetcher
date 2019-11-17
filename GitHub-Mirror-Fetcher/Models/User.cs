using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHub_Mirror_Fetcher.Models
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string company { get; set; }
        public string location { get; set; }
        public string email { get; set; }
        public string created_at { get; set; }
        public string type { get; set; }
        public int fake { get; set; }
        public int deleted { get; set; }
    }
}
