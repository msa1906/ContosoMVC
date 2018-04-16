using System;
using System.Collections.Generic;

namespace Contoso.Model
{
    public class Role
    {
        public int ID { get; set; }
        public string RoleName { get; set; }
        public string description { get; set; }
        public DateTime CreatedDate { get; set; }
        public String CreatedBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public String UpdateBy { get; set; }
        public ICollection<Person> People { get; set; }
    }
}