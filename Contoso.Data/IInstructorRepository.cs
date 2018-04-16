using Contoso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Data
{
    interface IInstructorRepository:IDisposable
    {
        IEnumerable<Instructor> GetInstructors();
        Instructor GetInstructorByID(int InstructorId);
        void InsertInstructor(Instructor Instructor);
        void DeleteInstructor(int InstructorID);
        void UpdateInstructor(Instructor Instructor);
        void Save();
    }
}
