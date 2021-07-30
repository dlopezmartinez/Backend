using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Metaenlace.Models;
using Metaenlace.Repositories;
using AutoMapper;
using Metaenlace.DTOs;
using Metaenlace.Services;

namespace Metaenlace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        private readonly IMedicoService service;
        private readonly IMapper mapper;

        public MedicosController(IMedicoService service ,IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        // GET: api/Medicos
        [HttpGet]
        public IActionResult GetMedicos()
        {
            ICollection<MedicoDTO> medicosDTO = new List<MedicoDTO>();
            foreach (Medico m in service.FindAll())
            {
                medicosDTO.Add(mapper.Map<MedicoDTO>(m));
            }

            return Ok(medicosDTO);
        }
        // GET: api/Pacientes/5
        [HttpGet("{id}")]
        public IActionResult GetMedico(long id)
        {

            Medico m = service.FindById(id);
            MedicoDTO dto = mapper.Map<MedicoDTO>(m);
            Medico m1 = mapper.Map<Medico>(dto);
            return Ok(m1);

        }


        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult create(Medico m)
        {
            service.Save(m);
            return Ok(mapper.Map<MedicoDTO>(m));
        }
        // PUT: api/Pacientes
        [HttpPut]
        public IActionResult AddPaciente(MedicoPacienteDTO relacion)
        {
            if (service.AddPaciente(relacion))
                return Ok(mapper.Map<MedicoDTO>(service.FindById(relacion.medID)));
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
