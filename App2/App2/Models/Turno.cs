using SQLite;
using SQLiteNetExtensions.Attributes;
using System;

namespace Care_Taker.Models
{
    [Table("Turnos")]
    public class Turno
    {
        [PrimaryKey, AutoIncrement]
        public int CodTurn { get; set; }
        [MaxLength(100)]
        public string Descripcion { get; set; }
        [ForeignKey(typeof(Dia))]
        public int CodDia { get; set; }
        public TimeSpan TimeIn { get; set; }
        public TimeSpan TimeOut { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Dia Dia { get; set; }
    }
}
