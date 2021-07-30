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

namespace Metaenlace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService service;
        public IMapper mapper;



        public UsuariosController(IUsuarioService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        // GET: api/Usuarios
        [HttpGet]
        public IActionResult GetUsuario()
        {
            return Ok(service.FindAll());
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public IActionResult GetUsuario(int id)
        {
            var usuario = service.FindById(id);
            return Ok(usuario);
        }

        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult create(Usuario usuario)
        {
            service.Save(usuario);
            return Ok(usuario);
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
