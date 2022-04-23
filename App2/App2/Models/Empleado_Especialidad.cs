using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Care_Taker.Models
{
    [Table("Empleado_Especialidades")]
    public class Empleado_Especialidad
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [ForeignKey(typeof(Empleado))]
        public int CodEmpl { get; set; }
        [ForeignKey(typeof(Especialidad))]
        public int CodEspe { get; set; }


        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Especialidad Especialidad { get; set; }
    }
}
