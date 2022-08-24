using Consulting.Domain.Commom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consulting.Domain.Entities
{
    public class Doctor: AuditEntity
    {
        public string Prefix { get; set; }
        public string FistName { get; set; }
        public string SecondName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PrincipalRole { get; set; }
        public string Status { get; set; }
        public string Email { get; set; }
        public string Specialty { get; set; }
        public string University { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
