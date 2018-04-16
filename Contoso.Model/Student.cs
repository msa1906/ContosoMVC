using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contoso.Model
{
    public class Student
    {
        [Key]
        [ForeignKey("Person")]
        public int ID { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public Person Person { get; set; }
    }
}