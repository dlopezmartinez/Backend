using Metaenlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Metaenlace.Repositories;

namespace Metaenlace.Services
{
    public class DiagnosticoService : IDiagnosticoService
    {

        private readonly BDContext context;

        public DiagnosticoService(BDContext context)
        {
            this.context = context;
        }

        public void DeleteById(long id)
        {
            Diagnostico d = context.Diagnostico.Find(id);
            context.Diagnostico.Remove(d);
        }

        public ICollection<Diagnostico> FindAll()
        {
            return context.Diagnostico.ToList();
        }

        public Diagnostico FindById(long id)
        {
            return context.Diagnostico.Find(id);
        }

        public bool Save(Diagnostico diagnostico)
        {
            context.Diagnostico.Add(diagnostico);
            context.SaveChanges();
            return true;
        }
    }
}
