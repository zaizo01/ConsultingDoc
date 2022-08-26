using AutoMapper;
using Consulting.Domain.Entities;
using Consulting.Infraestructure.DTOs.Doctor;
using Consulting.Service.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consulting.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IGenericRepository<Doctor> genericRepository;
        private readonly IMapper mapper;

        public DoctorController(IGenericRepository<Doctor> genericRepository, IMapper mapper)
        {
            this.genericRepository = genericRepository;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntityById(Guid id)
        {
            try
            {
                var entity = await genericRepository.GetById(id);
                if (entity.Data is null) return NotFound("Esta entidad no existe.");
                mapper.Map<DoctorGetDTO>(entity.Data);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEntities()
        {
            try
            {
                var entities = await genericRepository.GetAll();
                mapper.Map<List<DoctorGetDTO>>(entities.Data);
                return Ok(entities);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateEntity(DoctorPostDTO DoctorPostDTO)
        {
            try
            {
                var entity = mapper.Map<Doctor>(DoctorPostDTO);
                return Ok(await genericRepository.Create(entity));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEntity(DoctorPutDTO DoctorPutDTO)
        {
            try
            {
                var entity = mapper.Map<Doctor>(DoctorPutDTO);
                return Ok(await genericRepository.Update(entity));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntity(Guid id)
        {
            try
            {
                var response = await genericRepository.Delete(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
