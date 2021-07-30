using Metaenlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Metaenlace.Repositories;
using Metaenlace.DTOs;
using AutoMapper;

namespace Metaenlace.Services
{
    public class CitaService : ICitaService
    {
        private BDContext context;
        private IMapper mapper;

        public CitaService(BDContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public bool AddCita(CitaDTO citaDTO)
        {
            Paciente p = context.Pacientes.Find(citaDTO.pacienteID);
            Medico m = context.Medicos.Find(citaDTO.medicoID);

            if (m is null || p is null)
                return false;

            context.Add(mapper.Map<Cita>(citaDTO));
            return true;
        }

        public void AddDiagnostico(DiagnosticoDTO diagnostico)
        {
            Cita c = this.FindById(diagnostico.citaID);
            c.diagnostico = mapper.Map<Diagnostico>(diagnostico);

        }


        public void DeleteById(long id)
        {
            Cita c = context.Citas.Find(id);
            context.Citas.Remove(c);

        }

        public ICollection<Cita> FindAll() => context.Citas.ToList();

        public Cita FindById(long id)
        {
            return context.Citas.Find(id);
        }

        public bool Save(Cita cita)
        {
            context.Citas.Add(cita);
            context.SaveChanges();
            return true;
        }
    }
}
