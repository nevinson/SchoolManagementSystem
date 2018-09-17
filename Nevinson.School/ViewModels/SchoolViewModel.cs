using System.Collections.Generic;
using Nevinson.School.Models;

namespace Nevinson.School.ViewModels
{
    public class SchoolViewModel
    {
        public int Id { get; set; }
        public string SchoolName { get; set; }
        public List<Teacher> Teachers { get; set; }
    }
}
