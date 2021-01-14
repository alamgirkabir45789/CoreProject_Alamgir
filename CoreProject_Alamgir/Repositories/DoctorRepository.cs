using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreProject_Alamgir.Data;
using CoreProject_Alamgir.Models;

namespace CoreProject_Alamgir.Models
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ApplicationDbContext db;

        public DoctorRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public Doctor Add(Doctor doctor)
        {
            db.Doctors.Add(doctor);
            db.SaveChanges();
            return doctor;
        }

        public Doctor Delete(int Id)
        {
            Doctor doctor = db.Doctors.Find(Id);
            if(doctor != null)
            {
                db.Doctors.Remove(doctor);
                db.SaveChanges();
            }
            return doctor;
        }

        public IEnumerable<Doctor> GetAll()
        {
            return db.Doctors;
        }

        public Doctor GetStudent(int Id)
        {
            return db.Doctors.Where(x => x.Id == Id).SingleOrDefault();
        }

        public Doctor Update(Doctor doctor)
        {
            db.Entry(doctor).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return doctor;
        }
    }
}
