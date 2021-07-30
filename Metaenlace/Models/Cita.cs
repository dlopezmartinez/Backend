using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metaenlace.Models
{
    public class Cita
    {
        public long ID { get; set; }
        public DateTime fecha { get; set; }
        public string motivo { get; set; }
        public Usuario medico { get; set; }
        public Paciente paciente { get; set; }
        public Diagnostico diagnostico { get; set; }
        public Cita()
        {
        }

        public Cita(DateTime fecha, string motivo)
        {
            this.fecha = fecha;
            this.motivo = motivo;
        }




    }
}
