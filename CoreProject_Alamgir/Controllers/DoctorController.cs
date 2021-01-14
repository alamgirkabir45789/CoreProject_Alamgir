using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreProject_Alamgir.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace CoreProject_Alamgir.Controllers
{
    public class DoctorController : Controller
    {
        private IDoctorRepository db;
        private readonly IHostingEnvironment appEnvironment;

        public DoctorController(IDoctorRepository db , IHostingEnvironment appEnvironment)
        {
            this.db = db;
            this.appEnvironment = appEnvironment;
        }
        public IActionResult Index()
        {
            return View(db.GetAll());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                string UrlImage = "";

                var files = HttpContext.Request.Form.Files;
                foreach (var Image in files)
                {
                    if (Image != null && Image.Length > 0)
                    {
                        var file = Image;

                        var uploads = Path.Combine(appEnvironment.WebRootPath, "images");
                        if (file.Length > 0)
                        {
                             var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                            //var fileName = Guid.NewGuid().ToString().Replace("-", "") + file.FileName;
                            using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                                UrlImage = fileName;

                            }

                        }
                    }
                }

                var data = new Doctor()
                {
                    Name = doctor.Name,
                    Address = doctor.Address,
                    Email = doctor.Email,
                    PhoneNo = doctor.PhoneNo,
                    JoiningDate = doctor.JoiningDate,
                    Age = doctor.Age,
                    UrlImage = UrlImage,
                   
                };

                db.Add(data);
                return RedirectToAction(nameof(Index));

            }

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(db.GetStudent(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit( int id,Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                string UrlImage = "";
                var files = HttpContext.Request.Form.Files;
                foreach (var Image in files)
                {
                    if (Image != null && Image.Length > 0)
                    {
                        var file = Image;

                        var uploads = Path.Combine(appEnvironment.WebRootPath, "images");
                        if (file.Length > 0)
                        {
                            // var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                            var fileName = Guid.NewGuid().ToString().Replace("-", "") + file.FileName;
                            using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                                UrlImage = fileName;
                            }

                        }
                    }
                }
                var data = db.GetStudent(id);
                data.Name = doctor.Name;
                data.Address = doctor.Address;
                data.Email = doctor.Email;
                data.PhoneNo = doctor.PhoneNo;
                data.JoiningDate = doctor.JoiningDate;
                data.Age = doctor.Age;
                data.UrlImage = UrlImage;

                db.Update(data);
                return RedirectToAction(nameof(Index));

            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            return View(db.GetStudent(id));
        }
    }
}