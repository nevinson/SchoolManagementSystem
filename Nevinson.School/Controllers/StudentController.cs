﻿using Microsoft.AspNetCore.Mvc;
using Nevinson.School.Models;
using Nevinson.School.Services;
using Microsoft.AspNetCore.Authorization;

namespace Nevinson.School.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {

        private IStudentService _studentService;
        private ITeacherService _teacherService;
        public StudentController(IStudentService studentService, ITeacherService teacherService)
        {
            _studentService = studentService;
            _teacherService = teacherService;
        }
        [AllowAnonymous]
        public IActionResult AllStudents()
        {
                return View(_studentService.GetAllStudents());
        }

            public IActionResult CreateStudent()
        {
            ViewBag.Teachers = _teacherService.GetAllTeachers();
            return View();
        }
        public IActionResult StudentCreated(Student student)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Teachers = _teacherService.GetAllTeachers();
                ModelState.AddModelError(string.Empty, "Something went wrong");
                return View("CreateStudent");
            }
            _studentService.AddStudent(student);
            return View();
        }
        public IActionResult EditStudent(int id)
        {
            ViewBag.Teachers = _teacherService.GetAllTeachers();
            return View(_studentService.GetSingleStudentById(id));
        }
        public IActionResult StudentEdited(Student newStudent)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Something went wrong");
                ViewBag.Teachers = _teacherService.GetAllTeachers();
                return View("EditStudent", newStudent);
            }
            _studentService.UpdateStudent(newStudent);
            return View();

        }

        public IActionResult DeleteStudent(int id) => View(_studentService.StudentDeletionConfirmation(id));


        public IActionResult StudentDeleted(int id)
        {
            _studentService.DeleteStudent(id);
            return View();

        }
    }
}