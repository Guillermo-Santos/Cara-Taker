using System;
using SQLite;

namespace Care_Taker.Models
{
    [Table("Examenes_Resultado")]
    public class Examen_Resultado
    {
        public int CodCita { get; set; }
        public int CodExmn { get; set; }
    }
}
