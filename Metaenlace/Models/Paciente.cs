using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metaenlace.Models
{
    public class Paciente : Usuario
    {

        public string nss { get; set; }
        public string tarjeta { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public ICollection<Medico> Medicos { get; set; }

        public Paciente()
        {

        }

        public Paciente(string nombre, string apellidos, string usuario, string pass, string nss, string tarjeta, string telefono, string direccion) : base(Tipo.PACIENTE, nombre, apellidos, usuario, pass)
        {
            this.nss = nss;
            this.tarjeta = tarjeta;
            this.telefono = telefono;
            this.direccion = direccion;
            this.Medicos = new List<Medico>();
        }

    }
}
