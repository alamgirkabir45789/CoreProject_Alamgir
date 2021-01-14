using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreProject_Alamgir.Data;
using CoreProject_Alamgir.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreRpsCrud_Elias.Controllers
{
    public class InternDoctorController : Controller
    {
        private IInternDoctorRepository db;

        private IDepartmentRepository db2;

        private readonly ApplicationDbContext _context;


        public InternDoctorController(IInternDoctorRepository db, IDepartmentRepository db2, ApplicationDbContext _context)
        {
            this.db = db;
            this.db2 = db2;

            this._context = _context;
        }
        public IActionResult Index()
        {

            //ViewBag.CourseName = db2.GetAll();
            //var applicationDbContext = _context.Courses.Include(t => t.CourseName);
            var applicationDbContext = _context.Departments.ToList();

            return View(db.GetAll());
        }



        // GET:Create
        public IActionResult Create()
        {
            ViewBag.DepartmentID = db2.GetAll();

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(InternDoctor internDoctor)
        {
            ViewBag.DepartmentID=db2.GetAll();
            db.Add(internDoctor);
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int id)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var applicationDbContext = _context.Departments.ToList();
            ViewBag.DepartmentID = db2.GetAll();

            return View(db.GetInternDoctor(id));
        }

        [HttpPost]
        public IActionResult Edit(InternDoctor internDoctor)
        {
            ViewBag.DepartmentID = db2.GetAll();
            db.Update(internDoctor);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            return View(db.GetInternDoctor(id));
        }
    }
}