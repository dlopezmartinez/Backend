using Metaenlace.DTOs;
using Metaenlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Metaenlace.Services
{
    public interface IMedicoService
    {
		public ICollection<Medico> FindAll();

		public Medico FindById(long id);

		public bool Save(Medico medico);

		public void DeleteById(long id);

		public bool AddPaciente(MedicoPacienteDTO relacion);

		public ICollection<Medico> FindList(ICollection<long> lista);
	}
}
