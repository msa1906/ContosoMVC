using Contoso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Data
{
    interface IEnrollmentRepository: IDisposable
    {
        IEnumerable<Enrollment> GetEnrollments();
        Enrollment GetEnrollmentByID(int EnrollmentId);
        void InsertEnrollment(Enrollment Enrollment);
        void DeleteEnrollment(int EnrollmentID);
        void UpdateEnrollment(Enrollment Enrollment);
        void Save();
    }
}
