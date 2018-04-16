using Contoso.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Data
{
    class DepartmentRepository: IDepartmentRepository, IDisposable
    {
        private ContosoContext context;

        public DepartmentRepository(ContosoContext context)
        {
            this.context = context;
        }

        public IEnumerable<Department> GetDepartments()
        {
            return context.Departments.ToList();
        }

        public Department GetDepartmentByID(int id)
        {
            return context.Departments.Find(id);
        }

        public void InsertDepartment(Department Department)
        {
            context.Departments.Add(Department);
        }

        public void DeleteDepartment(int DepartmentID)
        {
            Department Department = context.Departments.Find(DepartmentID);
            context.Departments.Remove(Department);
        }

        public void UpdateDepartment(Department Department)
        {

            context.Entry(Department).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
