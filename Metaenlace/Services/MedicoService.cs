using Metaenlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Metaenlace.Repositories;
using Microsoft.EntityFrameworkCore;
using Metaenlace.DTOs;
using System.Linq.Expressions;

namespace Metaenlace.Services
{
    public class MedicoService : IMedicoService
    {
        private BDContext context;

        public MedicoService(BDContext context)
        {
            this.context = context;
        }

        public void DeleteById(long id)
        {
            Medico m = context.Medicos.Find(id);
            context.Medicos.Remove(m);
            context.SaveChanges();

        }

        public ICollection<Medico> FindAll() => context.Medicos.Include(m=>m.Pacientes).ToList();

        public Medico FindById(long id)
        {
            return context.Medicos.Where(m => m.ID == id).Include(m => m.Pacientes).First();
        }

        public bool Save(Medico medico)
        {
            context.Medicos.Add(medico);
            context.SaveChanges();
            return true;
        }

        public bool AddPaciente(MedicoPacienteDTO relacion)
        {
            Medico m  = FindById(relacion.medID);
            Paciente p = context.Pacientes.Where(p => p.ID == relacion.pacID).Include(p => p.Medicos).First();

            if (p is null || m is null)
                return false;
            if (!p.Medicos.Contains(m))
                p.Medicos.Add(m);
            if (!m.Pacientes.Contains(p))
                m.Pacientes.Add(p);

            context.SaveChanges();
            return true;
        }

        public ICollection<Medico> FindList(ICollection<long> lista)
        {
            if (lista.Count == 0)
                return new List<Medico>();
            List<Medico> medicos = new List<Medico>();
            var med = context.Medicos.Select(m => m.ID);
            foreach(long m in med)
            {
                medicos.Add(context.Medicos.Find(m));
            }
            return medicos;
        }

    }
}
