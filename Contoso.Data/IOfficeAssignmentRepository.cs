using Contoso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Data
{
    interface IOfficeAssignmentRepository:IDisposable
    {
        IEnumerable<OfficeAssignment> GetOfficeAssignments();
        OfficeAssignment GetOfficeAssignmentByID(int OfficeAssignmentId);
        void InsertOfficeAssignment(OfficeAssignment OfficeAssignment);
        void DeleteOfficeAssignment(int OfficeAssignmentID);
        void UpdateOfficeAssignment(OfficeAssignment OfficeAssignment);
        void Save();
    }
}
