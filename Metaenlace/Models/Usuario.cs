using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metaenlace.Models
{

    public enum Tipo
    {
        MEDICO, PACIENTE
    }



    public class Usuario
    {
        public long ID { get; set; }
        public Tipo tipo { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string nickname { get; set; }
        public string pass { get; set; }


        public Usuario()
        {

        }
        public Usuario(Tipo tipo, string nombre, string apellidos, string user, string pass)
        {
            this.tipo = tipo;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.nickname = user;
            this.pass = pass;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Usuario: \n");
            sb.Append("tipo: " + tipo + "\n");
            sb.Append("nombre: " + nombre + apellidos);


            return sb.ToString();
        }
    }
}
