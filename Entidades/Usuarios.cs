using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeraPruebaTarea5.Entidades
{
    public class Usuarios
    {
        [Key]
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string ClaveUsuario { get; set; }
        public string Email { get; set; }
        public DateTime FechaUSuario { get; set; }
        public string AliasUsuario { get; set; }
        public string IdRol { get; set; }
        public bool Activo { get; set; }
    }
}
