using Contoso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Data
{
    interface IDepartmentRepository: IDisposable
    {
        IEnumerable<Department> GetDepartments();
        Department GetDepartmentByID(int DepartmentId);
        void InsertDepartment(Department Department);
        void DeleteDepartment(int DepartmentID);
        void UpdateDepartment(Department Department);
        void Save();
    }
}
