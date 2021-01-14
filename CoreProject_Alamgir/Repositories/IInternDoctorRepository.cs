using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProject_Alamgir.Models
{
    public interface IInternDoctorRepository
    {
        InternDoctor GetInternDoctor(int id);

        IEnumerable<InternDoctor> GetAll();

        InternDoctor Add(InternDoctor internDoctor);
        InternDoctor Update(InternDoctor internDoctor);
        InternDoctor Delete(int id);
    }
}
