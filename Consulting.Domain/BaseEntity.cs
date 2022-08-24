using System;
using System.ComponentModel.DataAnnotations;

namespace Consulting.Domain
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
