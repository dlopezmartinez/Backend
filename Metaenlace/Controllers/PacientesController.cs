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
using Metaenlace.DTOs;
using AutoMapper;

namespace Metaenlace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteService service;
        private IMapper mapper;

        public PacientesController(IPacienteService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        // GET: api/Pacientes
        [HttpGet]
        public IActionResult GetPaciente()
        {
            ICollection<PacienteDTO> pacientesDTO = new List<PacienteDTO>();
            foreach(Paciente p in service.FindAll())
            {
                pacientesDTO.Add(mapper.Map<PacienteDTO>(p));
            }

            return Ok(pacientesDTO);
        }
        // GET: api/Pacientes/5
        [HttpGet("{id}")]
        public IActionResult GetPaciente(long id)
        {

            Paciente p = service.FindById(id);
            PacienteDTO dto = mapper.Map<PacienteDTO>(p);
            return Ok(dto);

        }

        
        // POST: api/Paciente
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult create(Paciente p)
        {
            service.Save(p);
            return Ok(mapper.Map<PacienteDTO>(p));
        }
        // PUT: api/Pacientes
        [HttpPut]
        public IActionResult AddMedico(MedicoPacienteDTO relacion)
        {
            if (service.AddMedico(relacion))
                return Ok(mapper.Map<PacienteDTO>(service.FindById(relacion.pacID)));
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
