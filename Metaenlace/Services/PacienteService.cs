using Metaenlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Metaenlace.Repositories;
using Microsoft.EntityFrameworkCore;
using Metaenlace.DTOs;

namespace Metaenlace.Services
{
    public class PacienteService : IPacienteService
    {

        private BDContext context;
  

        public PacienteService(BDContext context)
        {
            this.context = context;
      
        }

        public bool AddMedico(MedicoPacienteDTO relacion)
        {
            Paciente p = FindById(relacion.pacID);
            Medico m = context.Medicos.Where(m => m.ID == relacion.medID).Include(m => m.Pacientes).First();

            if (p is null || m is null)
                return false;
            if (!p.Medicos.Contains(m))
                p.Medicos.Add(m);
            if (!m.Pacientes.Contains(p))
                m.Pacientes.Add(p);

            context.SaveChanges();
            return true;
        }

        public void DeleteById(long id)
        { 
            Paciente p = context.Pacientes.Find(id);
            context.Pacientes.Remove(p);
            context.SaveChanges();
            
        }

        public ICollection<Paciente> FindAll()
        {

           return context.Pacientes.Include(p => p.Medicos).ToList();

        }

        public Paciente FindById(long id)
        {
            return context.Pacientes.Where(p => p.ID == id).Include(p => p.Medicos).First(); 
        }

        public bool Save(Paciente paciente)
        {
            context.Pacientes.Add(paciente);
            context.SaveChanges();
            return true;
        }

        public ICollection<Paciente> FindList(ICollection<long> lista)
        {
            if (lista.Count == 0)
                return new List<Paciente>();
            List<Paciente> medicos = new List<Paciente>();
            var med = context.Medicos.Select(m => m.ID);
            foreach (long m in med)
            {
                medicos.Add(context.Pacientes.Find(m));
            }
            return medicos;
        }
    }
}
