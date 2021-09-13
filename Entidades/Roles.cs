using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroCompletoWPF.Entidades
{
    class Roles
    {
        [Key]
        public int RolID { get; set; }
        public DateTime FechaCreacion { get; set; }
        public String Descripcion { get; set; }
        public String Nombres { get; set; }
        public String Email { get; set; }
        public String Contraseña { get; set; }
    }
}
