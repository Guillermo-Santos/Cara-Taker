using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Care_Taker.Models
{
    [Table("Examenes_Resultado")]
    public class Examen_Resultado
    {
        [PrimaryKey, ForeignKey(typeof(Cita))]
        public int CodCita { get; set; }
        [PrimaryKey, ForeignKey(typeof(Examen))]
        public int CodExmn { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Examen Examen { get; set; }
        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Cita Cita { get; set; }
    }
}
