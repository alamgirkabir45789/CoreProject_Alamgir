using CoreProject_Alamgir.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProject_Alamgir.Models
{
    public class InternDoctorRepository : IInternDoctorRepository
    {

        private readonly ApplicationDbContext db;

        public InternDoctorRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public InternDoctor Add(InternDoctor internDoctor)
        {
            db.InternDoctors.Add(internDoctor);
            db.SaveChanges();

            return internDoctor;
        }

        public InternDoctor Delete(int id)
        {
            InternDoctor internDoctor = db.InternDoctors.Find(id);
            if (internDoctor != null)
            {
                db.InternDoctors.Remove(internDoctor);
                db.SaveChanges();
            }
            return internDoctor;
        }

        public IEnumerable<InternDoctor> GetAll()
        {
            return db.InternDoctors;
        }

        public InternDoctor GetInternDoctor(int id)
        {
            return db.InternDoctors.Where(x => x.InternDoctorID == id).SingleOrDefault();

        }

        public InternDoctor Update(InternDoctor internDoctor)
        {
            db.Entry(internDoctor).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return internDoctor;
        }
    }
}
