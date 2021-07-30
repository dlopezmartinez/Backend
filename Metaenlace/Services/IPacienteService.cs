using Metaenlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Metaenlace.DTOs;

namespace Metaenlace.Services
{
    public interface IPacienteService
    {
		public ICollection<Paciente> FindAll();

		public Paciente FindById(long id);

		public bool Save(Paciente paciente);

		public void DeleteById(long id);
		public bool AddMedico(MedicoPacienteDTO relacion);

		public ICollection<Paciente> FindList(ICollection<long> lista);
	}
}
