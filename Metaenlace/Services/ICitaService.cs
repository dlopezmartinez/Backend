using Metaenlace.DTOs;
using Metaenlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metaenlace.Services
{
    public interface ICitaService
    {
		public ICollection<Cita> FindAll();

		public Cita FindById(long id);

		public bool Save(Cita cita);

		public void DeleteById(long id);
        bool AddCita(CitaDTO citaDTO);
    }
}
