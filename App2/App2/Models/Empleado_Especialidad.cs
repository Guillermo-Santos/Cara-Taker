using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Care_Taker.Models
{
    [Table("Empleado_Especialidades")]
    public class Empleado_Especialidad
    {
        [ForeignKey(typeof(Empleado))]
        public int CodEmpl { get; set; }
        [ForeignKey(typeof(Especialidad))]
        public int CodEspe { get; set; }

        [ManyToOne]
        public Empleado Empleado { get; set; }
        [ManyToOne]
        public Especialidad Especialidad { get; set; }
    }
}
