using System;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Care_Taker.Models
{
    [Table("Examenes_Cita")]
    public class Examen_Cita
    {
        [ForeignKey(typeof(Cita))]
        public int CodCita { get; set; }
        [ForeignKey(typeof(Tipo_Examen))]
        public int CodTpEx { get; set; }

        [ManyToOne]
        public Cita Cita { get; set; }
        [ManyToOne]
        public Tipo_Examen TipoExamen { get; set; }
    }
}
