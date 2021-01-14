using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreProject_Alamgir.Data;
using CoreProject_Alamgir.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CoreProject_Alamgir.Helper;

namespace CoreProject_Alamgir.Controllers
{
    public class PatientController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Patients.ToListAsync());
        }
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Patient());
            else
            {
                var patientModel = await _context.Patients.FindAsync(id);
                if (patientModel == null)
                {
                    return NotFound();
                }
                return View(patientModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("PatientID,PatientName,Address,ContactNo,Email,Department,AppointmentDate")] Patient patientModel)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    patientModel.AppointmentDate = DateTime.Now;
                    _context.Add(patientModel);
                    await _context.SaveChangesAsync();

                }
                else
                {
                    try
                    {
                        _context.Update(patientModel);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!PatientModelExists(patientModel.PatientID))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Patients.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", patientModel) });
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientModel = await _context.Patients
                .FirstOrDefaultAsync(m => m.PatientID == id);
            if (patientModel == null)
            {
                return NotFound();
            }

            return View(patientModel);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patientModel = await _context.Patients.FindAsync(id);
            _context.Patients.Remove(patientModel);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Patients.ToList()) });
        }

        private bool PatientModelExists(int id)
        {
            return _context.Patients.Any(e => e.PatientID == id);
        }
    }
}
