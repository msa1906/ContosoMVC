using Contoso.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Data
{
    class CourseRepository:ICourseRepository, IDisposable
    {
        private ContosoContext context;

        public CourseRepository(ContosoContext context)
        {
            this.context = context;
        }

        public IEnumerable<Course> GetCourses()
        {
            return context.Courses.ToList();
        }

        public Course GetCourseByID(int id)
        {
            return context.Courses.Find(id);
        }

        public void InsertCourse(Course Course)
        {
            context.Courses.Add(Course);
        }

        public void DeleteCourse(int CourseID)
        {
            Course Course = context.Courses.Find(CourseID);
            context.Courses.Remove(Course);
        }

        public void UpdateCourse(Course Course)
        {

            context.Entry(Course).State = EntityState.Modified;
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
