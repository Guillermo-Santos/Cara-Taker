using SQLite;
using System;

namespace Care_Taker.Models
{
    [Table("Citas")]
    public class Cita
    {
        [PrimaryKey, AutoIncrement]
        public int CodCita { get; set; }
        public int CodEmpl { get; set; }
        public int CodPaci { get; set; }
        public int CodTpCt { get; set; }
        public DateTime Fecha { get; set; }
        public string Resultado { get; set; }
        public bool Status { get; set; }

    }
}