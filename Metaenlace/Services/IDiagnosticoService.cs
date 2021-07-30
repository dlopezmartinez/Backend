using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Metaenlace.Models;

namespace Metaenlace.Services
{
    public interface IDiagnosticoService
    {
        public ICollection<Diagnostico> FindAll();

        public Diagnostico FindById(long id);

        public bool Save(Diagnostico diagnostico);

        public void DeleteById(long id);

    }
}
