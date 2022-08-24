using AutoMapper;
using Consulting.Domain.Entities;
using Consulting.Infraestructure.DTOs.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consulting.Infraestructure.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Doctor, DoctorGetDTO>().ReverseMap();
            CreateMap<Doctor, DoctorPostDTO>().ReverseMap();
            CreateMap<Doctor, DoctorPutDTO>().ReverseMap();
        }
    }
}
