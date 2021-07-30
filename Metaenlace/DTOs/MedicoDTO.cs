using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Metaenlace.Models;

namespace Metaenlace.DTOs
{
    public class MedicoDTO
    {
        public long ID { get; set; }
        public string numColegiado { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public ICollection<long> Pacientes { get; set; }

        public MedicoDTO(string numColegiado, string nombre, string apellidos)
        {
            this.numColegiado = numColegiado;
            this.nombre = nombre;
            this.apellidos = apellidos;
            Pacientes = new List<long>();
        }

  


    }
}
