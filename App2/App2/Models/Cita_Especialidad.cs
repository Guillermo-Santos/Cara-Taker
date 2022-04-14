using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Care_Taker.Models
{
    [Table("Cita_Especilidades")]
    public class Cita_Especialidad
    {
        [ForeignKey(typeof(Tipo_Cita))]
        public int CodTpCt { get; set; }
        [ForeignKey(typeof(Especialidad))]
        public int CodEspe { get; set; }

        [ManyToOne]
        public Tipo_Cita Tipo_Cita { get; set; }
        [ManyToOne]
        public Especialidad Especialidad { get; set; }
    }
}
