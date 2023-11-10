using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace BASE.Model
{
    [Table("Emisiones")]
    public class Emisiones
    {
       
       
            [PrimaryKey, AutoIncrement]
            public int Id_Emision { get; set; }

            [MaxLength(50),Unique]
            public String Mes { get; set; }

            [MaxLength(50)]
            public String Electricidad_consumida { get; set; }
            [MaxLength(50)]
            public String Gas_Consumido { get; set; }
            [MaxLength(50)]

            public String Cantidad_Residuos { get; set; }
            [MaxLength(330)]

            public String Tipo_Vehiculo { get; set; }
            [MaxLength(50)]
            public String Vehiculo_Consumo { get; set; }
            [MaxLength(50)]

            public String Vehiculo_Recorrido { get; set; }
          

          

        }
    }

