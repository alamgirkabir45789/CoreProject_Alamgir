using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProject_Alamgir.Models
{
    public interface IDoctorRepository
    {
        Doctor GetStudent(int Id);
        IEnumerable<Doctor> GetAll();

        Doctor Add(Doctor doctor);
        Doctor Update(Doctor doctor);
        Doctor Delete(int Id);
    }
}
