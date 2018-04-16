using Contoso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Data
{
    interface ICourseRepository: IDisposable
    {
        IEnumerable<Course> GetCourses();
        Course GetCourseByID(int CourseId);
        void InsertCourse(Course Course);
        void DeleteCourse(int CourseID);
        void UpdateCourse(Course Course);
        void Save();
    }
}
