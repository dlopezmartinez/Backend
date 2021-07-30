using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metaenlace.Models
{
    public class Medico : Usuario
    {

        public string numColegiado { get; set; }
        public ICollection<Paciente> Pacientes { get; set; }

        public Medico()
        {

        }

        public Medico(string nombre, string apellidos, string usuario, string pass, string colegiado) : base(Tipo.MEDICO, nombre, apellidos, usuario, pass)
        {
            this.numColegiado = colegiado;
            this.Pacientes = new List<Paciente>();
        }
    }
}
