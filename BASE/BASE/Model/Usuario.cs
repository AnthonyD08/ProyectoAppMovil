using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace BASE
{
    [Table("Usuario")]
    class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id_Usuario { get; set; }
        
        [MaxLength(50), Unique]
        public String Nombre { get; set; }

        [MaxLength(50)]
        public String Apellido1 { get; set; }
        [MaxLength(50)]
        public String Provincia { get; set; }
        [MaxLength(50)]

        public String Direccion { get; set; }
        [MaxLength(330)]

        public String Teléfono { get; set; }
        [MaxLength(50)]
        public String Correo { get; set; }
        [MaxLength(50)]

        public String Inscrito { get; set; }
        [MaxLength(50)]

        public String User { get; set; }
        [MaxLength(30), Unique]
        public String Clave { get; set; }

    }
}
