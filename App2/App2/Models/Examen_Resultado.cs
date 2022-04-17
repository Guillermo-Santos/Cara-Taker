using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Care_Taker.Models
{
    [Table("Examenes_Resultado")]
    public class Examen_Resultado
    {
        [ForeignKey(typeof(Cita))]
        public int CodCita { get; set; }
        [ForeignKey(typeof(Examen))]
        public int CodExmn { get; set; }

        [ManyToOne]
        public Examen Examen { get; set; }
        [ManyToOne]
        public Cita Cita { get; set; }
    }
}
