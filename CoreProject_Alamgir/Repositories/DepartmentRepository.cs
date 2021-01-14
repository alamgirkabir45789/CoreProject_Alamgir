using CoreProject_Alamgir.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProject_Alamgir.Models
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext db;

        public DepartmentRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public Department Add(Department department)
        {
            
            db.Departments.Add(department);
            db.SaveChanges();

            return department;
        }

        public Department Delete(int id)
        {
            Department department = db.Departments.Find(id);
            db.Departments.Remove(department);
            db.SaveChanges();

            return department;
        }

        public IEnumerable<Department> GetAll()
        {
            return db.Departments;
        }

        public Department GetDepartment(int id)
        {
            return db.Departments.Where(x => x.DepartmentID == id).SingleOrDefault();

        }

        public Department Update(Department department)
        {
            db.Entry(department).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return department;
        }
    }
}
