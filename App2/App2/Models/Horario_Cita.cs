using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Care_Taker.Models
{
    [Table("Horario_Citas")]
    public class Horario_Cita
    {
        [PrimaryKey, ForeignKey(typeof(Consultorio))]
        public int CodConsul { get; set; }
        [PrimaryKey, ForeignKey(typeof(Empleado))]
        public int CodEmpl { get; set; }
        [PrimaryKey, ForeignKey(typeof(Turno))]
        public int CodTurn { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Consultorio Consultorio { get; set; }
        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Empleado Empleado { get; set; }
        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Turno Turno { get; set; }
    }
}
