using System;
using System.ComponentModel.DataAnnotations;

namespace Contoso.Model
{
    public class Course
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public Department Department { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}