using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metaenlace.Models
{
    public class Diagnostico
    {
        public long ID { get; set; }
        public string valoracion { get; set; }
        public string enfermedad { get; set; }
        public Cita cita { get; set; }


        public Diagnostico()
        {

        }

        public Diagnostico(String valoracion, String enfermedad)
        {
            this.valoracion = valoracion;
            this.enfermedad = enfermedad;
        }
    }
}
