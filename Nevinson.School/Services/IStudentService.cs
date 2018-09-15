using System.Collections.Generic;
using Nevinson.School.Models;
using Nevinson.School.ViewModels;

namespace Nevinson.School.Services
{
    public interface IStudentService
    {
        List<Student> GetAllStudents();
        void AddStudent(Student student);
        Student GetSingleStudentById(int id);
        void UpdateStudent(Student newStudent);
        void DeleteStudent(int id);
        StudentViewModel StudentDeletionConfirmation(int id);
    }
}
