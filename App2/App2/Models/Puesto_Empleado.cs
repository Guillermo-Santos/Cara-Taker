using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace Care_Taker.Models
{
    [Table("Puestos_Empleado")]
    public class Puesto_Empleado
    {
        [PrimaryKey, AutoIncrement]
        public int CodPtEm { get; set; }
        [MaxLength(100)]
        public string Descripcion { get; set; }

        [OneToMany]
        public List<Empleado> Empleados { get; set; }
    }
}
