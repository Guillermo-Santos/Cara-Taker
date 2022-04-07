using SQLite;
using System;

namespace Care_Taker.Models
{
    [Table("Examenes")]
    public class Examen
    {
        [PrimaryKey,AutoIncrement]
        public int CodExmn { get; set; }
        public int CodPaci { get; set; }
        public int CodTpEx { get; set; }
        [MaxLength(255)]
        public string Documento { get; set; }
        public DateTime Fecha { get; set; }
        //[ForeignKey()]
    }
}
