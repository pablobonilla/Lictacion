using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.DataAccess.Entities
{
    public class Ministerio
    {//Las entidades tienen los mismos campos de la tabla de la base de datos,
        //además esto te permite  cambiar facilmente a Entity Framework.

        public int IdMinisterio { get; set; }
        public string NombreMinisterio { get; set; }
        public string Email { get; set; }
        public byte[] Photo { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

    }
}
