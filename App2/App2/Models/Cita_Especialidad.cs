using SQLite;

namespace Care_Taker.Models
{
    [Table("Cita_Especilidades")]
    public class Cita_Especialidad
    {
        public int CodTpCt { get; set; }
        public int CodEspe { get; set; }
    }
}
