using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Care_Taker.Models
{
    [Table("Horario_Citas")]
    public class Horario_Cita
    {
        [ForeignKey(typeof(Consultorio))]
        public int CodConsul { get; set; }
        [ForeignKey(typeof(Empleado))]
        public int CodEmpl { get; set; }
        [ForeignKey(typeof(Turno))]
        public int CodTurn { get; set; }

        [ManyToOne]
        public Consultorio Consultorio { get; set; }
        [ManyToOne]
        public Empleado Empleado { get; set; }
        [ManyToOne]
        public Turno Turno { get; set; }
    }
}
