using SQLite;

namespace Care_Taker.Models
{
    [Table("Horario_Citas")]
    public class Horario_Cita
    {
        public int CodConsul { get; set; }
        public int CodEmpl { get; set; }
        public int CodTurn { get; set; }
    }
}
