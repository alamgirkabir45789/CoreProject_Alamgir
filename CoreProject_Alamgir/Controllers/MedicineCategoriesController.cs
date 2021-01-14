using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreProject_Alamgir.Data;
using CoreProject_Alamgir.Models;

namespace CoreProject_Alamgir.Controllers
{
    public class MedicineCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public readonly IHostingEnvironment _hostingEnvironment;

        public MedicineCategoriesController(ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
        public async Task<ActionResult> Index()
        {
            ViewBag.MedicineCategoryID = new SelectList(_context.MedicineCategories, "ID", "Name");
            return View(await _context.MedicineCategories.ToListAsync());
        }
        public ActionResult GetCategoryWiseItems(long? id)
        {
            if (id == null)
            {
                NotFound();
            }

            ViewData["id"] = id;
            List<MedicineItem> items = _context.MedicineItems.Where(e => e.MedicineCategoryID == id).ToList();

            if (items == null)
            {
                NotFound();
            }

            return PartialView("CategoryWiseItems", items);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MedicineItem items, MedicineCategory medicineCategory, IFormFile[] Image)
        {
            try
            {

                if (Image != null)
                {
                    if (medicineCategory.MedicineItems.Count == Image.Count())
                    {
                        for (int i = 0; i < medicineCategory.MedicineItems.Count; i++)
                        {

                            string picture = System.IO.Path.GetFileName(Image[i].FileName);
                            var file = picture;
                            var uploadFile = Path.Combine(_hostingEnvironment.WebRootPath, "images", picture);

                            using (MemoryStream ms = new MemoryStream())
                            {
                                Image[i].CopyTo(ms);
                                medicineCategory.MedicineItems[i].Image = ms.GetBuffer();
                            }
                        }
                    }
                    _context.MedicineCategories.Add(medicineCategory);
                    _context.SaveChanges();
                    TempData["id"] = medicineCategory.ID;
                    return RedirectToAction("Index");
                }

                return View(medicineCategory);
            }
            catch (Exception)
            {
                return View(medicineCategory);
            }
        }


        //public ActionResult Edit(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var medicineCategory = _context.MedicineCategories.FindAsync(id);
        //    if (medicineCategory == null)
        //    {
        //        return NotFound();
        //    }
        //    return PartialView(medicineCategory);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(MedicineItem items, MedicineCategory medicineCategory, IFormFile[] Image)
        //{
        //    try
        //    {

        //        if (Image != null)
        //        {
        //            if (medicineCategory.MedicineItems.Count == Image.Count())
        //            {
        //                for (int i = 0; i < medicineCategory.MedicineItems.Count; i++)
        //                {

        //                    string picture = System.IO.Path.GetFileName(Image[i].FileName);
        //                    var file = picture;
        //                    var uploadFile = Path.Combine(_hostingEnvironment.WebRootPath, "images", picture);

        //                    using (MemoryStream ms = new MemoryStream())
        //                    {
        //                        Image[i].CopyTo(ms);
        //                        medicineCategory.MedicineItems[i].Image = ms.GetBuffer();
        //                    }
        //                }
        //            }
        //            _context.MedicineCategories.Add(medicineCategory);
        //            _context.Entry(medicineCategory).State = EntityState.Modified;
        //            _context.SaveChanges();
        //            TempData["id"] = medicineCategory.ID;
        //            return RedirectToAction("Index");
        //        }

        //        return View(medicineCategory);
        //    }
        //    catch (Exception)
        //    {
        //        return View(medicineCategory);
        //    }
        //}






        public IActionResult Delete(long id)
        {
            MedicineCategory medicineCategory = _context.MedicineCategories.Find(id);
            if (medicineCategory != null)
            {
                _context.MedicineCategories.Remove(medicineCategory);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeleteItem(long id)
        {
            MedicineItem item = _context.MedicineItems.Find(id);
            if (item != null)
            {
                _context.MedicineItems.Remove(item);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }
    }
}