using System.Collections.Generic;
using System.Linq;
using Nevinson.School.Data;
using Nevinson.School.Models;
using Nevinson.School.ViewModels;

namespace Nevinson.School.Services
{
    public class SchoolService : ISchoolService
    {
        private ApplicationDbContext _context;
        public SchoolService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddSchool(Models.School school)
        {
            _context.Schools.Add(school);
            _context.SaveChanges();
        }

        public void DeleteSchool(int id)
        {
            Models.School schoolToBeDeleted = GetSingleSchoolById(id);
            _context.Schools.Remove(schoolToBeDeleted);
            _context.SaveChanges();
        }

        public List<Models.School> GetAllSchools()
        {
           return _context.Schools.ToList();
        }

        public Models.School GetSingleSchoolById(int id) => _context.Schools.Where(n => n.Id == id).FirstOrDefault();

        public List<Teacher> GetTeachersBySchoolId(int schoolId) => _context.Teachers.Where(n => n.SchoolId == schoolId).ToList();
        

        public void UpdateSchool(Models.School newSchool)
        {
            Models.School oldSchool = GetSingleSchoolById(newSchool.Id);
            oldSchool.Address = newSchool.Address;
            oldSchool.FoundingYear = newSchool.FoundingYear;
            oldSchool.Name = newSchool.Name;
            oldSchool.NumberOfStudents = newSchool.NumberOfStudents;
            _context.SaveChanges();
        }

        public SchoolViewModel SchoolDeletionConfirmation(int id)
        {

            Models.School school = GetSingleSchoolById(id);
            SchoolViewModel schoolVM = new SchoolViewModel()
            {
                Id = school.Id,
                SchoolName = school.Name
            };

            return schoolVM;

        }

        public SchoolViewModel SchoolDetails(int id)
        {
            Models.School school = GetSingleSchoolById(id);
            SchoolViewModel schoolVM = new SchoolViewModel()
            {
                SchoolName = school.Name,
                Teachers = GetTeachersBySchoolId(id)
            };
            return schoolVM;

        }
    }
}
