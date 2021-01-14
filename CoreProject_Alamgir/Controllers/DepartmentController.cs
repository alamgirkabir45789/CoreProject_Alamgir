using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreProject_Alamgir.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject_Alamgir.Controllers
{
    public class DepartmentController : Controller
    {
        private IDepartmentRepository db;

        public DepartmentController(IDepartmentRepository db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View(db.GetAll());
        }



        // GET:Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department department)
        {

            db.Add(department);
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int id)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(db.GetDepartment(id));
        }

        [HttpPost]
        public IActionResult Edit(Department department)
        {
            db.Update(department);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            return View(db.GetDepartment(id));
        }
    }
}