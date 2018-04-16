using Contoso.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Data
{
    class OfficeAssignmentRepository:IOfficeAssignmentRepository, IDisposable
    {
        private ContosoContext context;

        public OfficeAssignmentRepository(ContosoContext context)
        {
            this.context = context;
        }

        public IEnumerable<OfficeAssignment> GetOfficeAssignments()
        {
            return context.OfficeAssignments.ToList();
        }

        public OfficeAssignment GetOfficeAssignmentByID(int id)
        {
            return context.OfficeAssignments.Find(id);
        }

        public void InsertOfficeAssignment(OfficeAssignment OfficeAssignment)
        {
            context.OfficeAssignments.Add(OfficeAssignment);
        }

        public void DeleteOfficeAssignment(int OfficeAssignmentID)
        {
            OfficeAssignment OfficeAssignment = context.OfficeAssignments.Find(OfficeAssignmentID);
            context.OfficeAssignments.Remove(OfficeAssignment);
        }

        public void UpdateOfficeAssignment(OfficeAssignment OfficeAssignment)
        {

            context.Entry(OfficeAssignment).State = EntityState.Modified;
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
