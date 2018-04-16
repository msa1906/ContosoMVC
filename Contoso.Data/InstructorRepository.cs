using Contoso.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Data
{
    class InstructorRepository: IInstructorRepository, IDisposable
    {
        private ContosoContext context;

        public InstructorRepository(ContosoContext context)
        {
            this.context = context;
        }

        public IEnumerable<Instructor> GetInstructors()
        {
            return context.Instructors.ToList();
        }

        public Instructor GetInstructorByID(int id)
        {
            return context.Instructors.Find(id);
        }

        public void InsertInstructor(Instructor Instructor)
        {
            context.Instructors.Add(Instructor);
        }

        public void DeleteInstructor(int InstructorID)
        {
            Instructor Instructor = context.Instructors.Find(InstructorID);
            context.Instructors.Remove(Instructor);
        }

        public void UpdateInstructor(Instructor Instructor)
        {

            context.Entry(Instructor).State = EntityState.Modified;
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
