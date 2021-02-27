using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeraPruebaTarea5.Entidades
{
    public class Roles
    {
        [Key]
        public int IdRol { get; set; }
        public string NombreRol { get; set; }
        public bool EsActivo { get; set; }
        [ForeignKey("IdRol")]
        public virtual List<RolesDetalle> Detalle { get; set; }

        public Roles()
        {
            IdRol = 0;
            NombreRol = string.Empty;
            EsActivo = false;
            Detalle = new List<RolesDetalle>();
        }

    }
}
