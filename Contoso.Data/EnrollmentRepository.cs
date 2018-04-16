using Contoso.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Data
{
    class EnrollmentRepository: IEnrollmentRepository, IDisposable
    {
        private ContosoContext context;

        public EnrollmentRepository(ContosoContext context)
        {
            this.context = context;
        }

        public IEnumerable<Enrollment> GetEnrollments()
        {
            return context.Enrollments.ToList();
        }

        public Enrollment GetEnrollmentByID(int id)
        {
            return context.Enrollments.Find(id);
        }

        public void InsertEnrollment(Enrollment Enrollment)
        {
            context.Enrollments.Add(Enrollment);
        }

        public void DeleteEnrollment(int EnrollmentID)
        {
            Enrollment Enrollment = context.Enrollments.Find(EnrollmentID);
            context.Enrollments.Remove(Enrollment);
        }

        public void UpdateEnrollment(Enrollment Enrollment)
        {

            context.Entry(Enrollment).State = EntityState.Modified;
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
