using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contoso.Model
{
    public class Person
    {
        [Key]
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int UnitOrApartmentNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public String CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public String Instructor { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public Boolean IsLocked { get; set; }
        public DateTime LastLockedDateTime { get; set; }
        public int FailedAttempts { get; set; }
        public DateTime DateofBirth { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}