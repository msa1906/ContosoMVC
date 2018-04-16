using System;

namespace Contoso.Model
{
    public class Enrollment
    {
        public int ID { get; set; }
        public Student Student { get; set; }
        public int Grade { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}