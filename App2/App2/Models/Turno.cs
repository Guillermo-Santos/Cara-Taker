using System;
using SQLite;

namespace Care_Taker.Models
{
    [Table("Turnos")]
    public class Turno
    {
        [PrimaryKey, AutoIncrement]
        public int CodTurn { get; set; }
        [MaxLength(100)]
        public string Descripcion { get; set; }
        public int CodDia { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }
    }
}
