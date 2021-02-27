using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeraPruebaTarea5.Entidades
{
   public class Permisos
    {
        [Key]
        public int IdPermiso { get; set; }
        public string NombrePermiso { get; set; }
        [ForeignKey("IdPermiso")]
        public virtual Permisos Permiso { get; set; }

        public Permisos()
        {
            IdPermiso = 0;
            NombrePermiso = string.Empty;
        }
    }
}
