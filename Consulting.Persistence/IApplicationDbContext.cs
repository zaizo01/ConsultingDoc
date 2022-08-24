using Consulting.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consulting.Infraestructure
{
    public interface IApplicationDbContext
    {
        DbSet<Doctor> Doctors { get; set; }
        Task<int> SaveChangesAsync();
    }
}
