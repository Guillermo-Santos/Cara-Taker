using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Care_Taker.Models
{
    [Table("Empleado_Especialidades")]
    public class Empleado_Especialidad
    {
        [PrimaryKey, ForeignKey(typeof(Empleado))]
        public int CodEmpl { get; set; }
        [PrimaryKey, ForeignKey(typeof(Especialidad))]
        public int CodEspe { get; set; }


        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Especialidad Especialidad { get; set; }
    }
}
