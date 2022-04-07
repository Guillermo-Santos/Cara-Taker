using System;
using SQLite;

namespace Care_Taker.Models
{
    [Table("Examenes_Cita")]
    public class Examen_Cita
    {
        public int CodCita { get; set; }
        public int CodTpEx { get; set; }
    }
}
