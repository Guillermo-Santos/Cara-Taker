using System;
using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;

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
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }

        [ManyToOne]
        public Dia Dia { get; set; }
        [OneToMany]
        public List<Horario_Cita> Horario_Citas { get; set; }
    }
}
