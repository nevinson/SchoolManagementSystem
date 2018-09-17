using System.Collections.Generic;
using Nevinson.School.Models;

namespace Nevinson.School.ViewModels
{
    public class TeacherViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<Student> Students { get; set; }
        public object TeacherName { get; internal set; }
    }
}
