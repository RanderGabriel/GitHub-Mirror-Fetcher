using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHub_Mirror_Fetcher.Models
{
    public class Project
    {
        public int id { get; set; }
        public string url { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string language { get; set; }
        public string created_at { get; set; }
        public int forked_from { get; set; }
        public int deleted { get; set; }
    }
}
