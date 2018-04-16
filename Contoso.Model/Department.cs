using System;

namespace Contoso.Model
{
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Budget { get; set; }
        public DateTime StartDate { get; set; }
        public Instructor Instructor { get; set; }
        public int RowVersion { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

    }
}