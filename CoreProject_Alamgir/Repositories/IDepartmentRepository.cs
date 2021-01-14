using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProject_Alamgir.Models
{
    public interface IDepartmentRepository
    {
        Department GetDepartment(int id);

        IEnumerable<Department> GetAll();

        Department Add(Department department);
        Department Update(Department department);
        Department Delete(int id);
    }
}
