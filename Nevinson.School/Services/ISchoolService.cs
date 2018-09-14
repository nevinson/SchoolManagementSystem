using System.Collections.Generic;
using Nevinson.School.Models;
using Nevinson.School.ViewModels;

namespace Nevinson.School.Services
{
    public interface ISchoolService
    {
        List<Models.School> GetAllSchools();
        void AddSchool(Models.School school);
        Models.School GetSingleSchoolById(int id);
        void UpdateSchool(Models.School newSchool);
        void DeleteSchool(int id);
        List<Teacher> GetTeachersBySchoolId(int schoolId);
        SchoolViewModel SchoolDeletionConfirmation(int id);
        SchoolViewModel SchoolDetails(int id);
    }
}
