using CodeTheWay.Web.Ui.Models;
using CodeTheWay.Web.Ui.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeTheWay.Web.Ui.Models.ViewModels;

namespace CodeTheWay.Web.Ui.Controllers
{
    public class StudentsController : Controller
    {
        private IStudentsService StudentService;

        public StudentsController(IStudentsService studentsService)
        {
            this.StudentService = studentsService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await StudentService.GetStudents());
        }
        public async Task<IActionResult> Create()
        {
            return View(new StudentRegistrationViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Register(StudentRegistrationViewModel model)
        {
            if (ModelState.IsValid && model.Age < 19)
            {
                Student student = new Student()
                {
                    Id = model.Id,
                    FirstMidName = model.FirstName,
                    LastName = model.LastName,

                }; 
                var student2 = await StudentService.Create(student);
                return RedirectToAction("Index");

            }
            else
            {
                return RedirectToAction("Index");

            }
            return View(model);
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            
            var student = await StudentService.GetStudent(id);
            StudentRegistrationViewModel stdt = new StudentRegistrationViewModel()
            {
                Id = student.Id,
                FirstName = student.FirstMidName,
                LastName = student.LastName,
                Age = 0,
                
            };
            return View(stdt);
        }
        [HttpPost]
        public async Task<IActionResult> UpDate(StudentRegistrationViewModel model)
        {
            if (ModelState.IsValid && model.Age < 19)
            {
                Student student = new Student
                {
                    Id = model.Id,
                    FirstMidName = model.FirstName,
                    LastName = model.LastName,
                };
                var student2 = await StudentService.Update(student);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
        public async Task<IActionResult> Details(Guid id)
        {
            var student = await StudentService.GetStudent(id);
            return View(student);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var student = await StudentService.GetStudent(id);
            await StudentService.Delete(student);
            return RedirectToAction("Index");
        }
    }
}
