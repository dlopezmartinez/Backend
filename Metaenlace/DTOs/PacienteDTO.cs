using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Metaenlace.Models;

namespace Metaenlace.DTOs
{
    public class PacienteDTO
    {
        
        public long ID { get; set; }
        public string nss { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public ICollection<long> Medicos { get; set; }

        public PacienteDTO(string nss, string nombre, string apellidos)
        {
            this.nss = nss;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.Medicos = new List<long>();
        }

 
    }
}
