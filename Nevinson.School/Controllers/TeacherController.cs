using Microsoft.AspNetCore.Mvc;
using Nevinson.School.Models;
using Nevinson.School.Services;
using Microsoft.AspNetCore.Authorization;

namespace Nevinson.School.Controllers
{
    [Authorize]
    public class TeacherController : Controller
    {
        private ITeacherService _teacherService;
        private ISchoolService _schoolService;
        public TeacherController(ITeacherService teacherService, ISchoolService schoolService)
        {
            _teacherService = teacherService;
            _schoolService = schoolService;

        }

        [AllowAnonymous]
        public IActionResult AllTeachers()
        {
            return View(_teacherService.GetAllTeachers());
        }
        public IActionResult CreateTeacher()
        {
            ViewBag.Schools = _schoolService.GetAllSchools();
            return View();
        }
        public IActionResult TeacherCreated(Teacher teacher)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Something went wrong");
                ViewBag.Schools = _schoolService.GetAllSchools();
                return View("CreateTeacher");
            }
            _teacherService.AddTeacher(teacher);
            return View();
        }
        public IActionResult EditTeacher(int id)
        {
            ViewBag.Schools = _schoolService.GetAllSchools();
            return View(_teacherService.GetSingleTeacherById(id));
        }
        public IActionResult TeacherEdited(Teacher newTeacher)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Something went wrong");
                ViewBag.Schools = _schoolService.GetAllSchools();
                return View("EditTeacher", newTeacher);
            }
            _teacherService.UpdateTeacher(newTeacher);
            return View();

        }

        public IActionResult DeleteTeacher(int id) => View(_teacherService.TeacherDeletionConfirmation(id));

        public IActionResult TeacherDeleted(int id)
        {
            _teacherService.DeleteTeacher(id);

            return View();
        }
        public IActionResult TeacherDetails(int id)
        {
            return View(_teacherService.TeacherDetails(id));
        }
    }
}