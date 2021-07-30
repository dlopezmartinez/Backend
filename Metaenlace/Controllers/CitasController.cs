using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Metaenlace.Models;
using Metaenlace.Repositories;
using Metaenlace.Services;
using AutoMapper;
using Metaenlace.DTOs;

namespace Metaenlace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitasController : ControllerBase
    {

        private readonly ICitaService service;
        private readonly IMapper mapper;

        public CitasController(ICitaService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        // GET: api/Citas
        [HttpGet]
        public IActionResult GetCitas()
        {
            ICollection<CitaDTO> citasDTO = new List<CitaDTO>();
            foreach (Cita c in service.FindAll())
            {
                citasDTO.Add(mapper.Map<CitaDTO>(c));
            }

            return Ok(citasDTO);
        }
        // GET: api/Citas/5
        [HttpGet("{id}")]
        public IActionResult GetCita(long id)
        {

            Cita c = service.FindById(id);
            CitaDTO dto = mapper.Map<CitaDTO>(c);
            return Ok(dto);

        }


        // POST: api/Citas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult create(Cita c)
        {
            service.Save(c);
            return Ok(mapper.Map<CitaDTO>(c));
        }
        // PUT: api/Citas
        
        [HttpPut]
        public IActionResult AddCita(CitaDTO dto)
        {           
           
            if (service.AddCita(dto))
                return Ok(dto);
            return Ok("El paciente o el médico no existe");
        }
        
        // DELETE: api/Pacientes/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            service.DeleteById(id);
            return Ok();
        }

    }
}
