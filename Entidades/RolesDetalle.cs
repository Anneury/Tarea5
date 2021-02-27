using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraPruebaTarea5.Entidades
{
    public class RolesDetalle
    {
        [Key]

        public int Id { get; set; }
        public int IdRol { get; set; }
        public int IdPermiso { get; set; }
        public bool EsAsignado { get; set; }

        public RolesDetalle()
        {
            Id = 0;
            IdRol = 0;
            IdPermiso = 0;
            EsAsignado = false;
        }

        public RolesDetalle(int Id, int IdRol, int IdPermiso, bool EsAsignado)
        {
            this.Id = Id;
            this.IdRol = IdRol;
            this.IdPermiso = IdPermiso;
            this.EsAsignado = EsAsignado;
        }
    }
}
