using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metaenlace.DTOs
{
    public class DiagnosticoDTO
    {
        public long ID { get; set; }
        public string valoracion { get; set; }
        public string enfermedad { get; set; }
        public long citaID { get; set; }

        public DiagnosticoDTO(string valoracion, string enfermedad, long citaID)
        {
            this.valoracion = valoracion;
            this.enfermedad = enfermedad;
            this.citaID = citaID;
        }
    }
}
