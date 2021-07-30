using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metaenlace.DTOs
{
    public class CitaDTO
    {
        public long ID { get; set; }
        public DateTime fecha { get; set; }
        public string motivo { get; set; }
        public long medicoID { get; set; }
        public long pacienteID { get; set; }
        public long diagnosticoID { get; set; }

        public CitaDTO(DateTime fecha, string motivo, long medicoID, long pacienteID, long diagnosticoID)
        {
            this.fecha = fecha;
            this.motivo = motivo;
            this.medicoID = medicoID;
            this.pacienteID = pacienteID;
            this.diagnosticoID = diagnosticoID;
        }
    }
}
