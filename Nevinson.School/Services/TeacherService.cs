﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Nevinson.School.Data;
using Nevinson.School.Models;
using Nevinson.School.ViewModels;

namespace Nevinson.School.Services
{
    public class TeacherService : ITeacherService
    {
        private ApplicationDbContext _context;
        public TeacherService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddTeacher(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
        }

        public void DeleteTeacher(int id)
        {
            Teacher teacherToBeDeleted = GetSingleTeacherById(id);
            _context.Teachers.Remove(teacherToBeDeleted);
            _context.SaveChanges();
        }

        public List<Teacher> GetAllTeachers()
        {
            List<Teacher> teachers = _context.Teachers.Include(n => n.School).ToList();
            return teachers;
        }

        public Teacher GetSingleTeacherById(int id) => _context.Teachers.Where(n => n.Id == id).FirstOrDefault();

        public List<Student> GetStudentsByTeacherId(int teacherId) => _context.Students.Where(n => n.TeacherId == teacherId).ToList();
        

        public void UpdateTeacher(Teacher newTeacher)
        {
            Teacher oldTeacher = GetSingleTeacherById(newTeacher.Id);
            oldTeacher.FullName = newTeacher.FullName;
            oldTeacher.Age = newTeacher.Age;
            oldTeacher.PhoneNumber = newTeacher.PhoneNumber;
            oldTeacher.YearsOfExperience = newTeacher.YearsOfExperience;
            oldTeacher.Subject = newTeacher.Subject;
            oldTeacher.SchoolId = newTeacher.SchoolId;
            _context.SaveChanges();
        }

        public TeacherViewModel TeacherDeletionConfirmation(int id)
        {

            Teacher teacher = GetSingleTeacherById(id);
            TeacherViewModel teacherVM = new TeacherViewModel()
            {
                Id = teacher.Id,
                TeacherName = teacher.FullName
            };

            return teacherVM;

        }

        public TeacherViewModel TeacherDetails(int id)
        {
            Teacher teacher = GetSingleTeacherById(id);
            TeacherViewModel teacherVM = new TeacherViewModel()
            {
                TeacherName = teacher.FullName,
                Students = GetStudentsByTeacherId(id)
            };
            return teacherVM;

        }
    }
}
