using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;

namespace Care_Taker.Models
{
    [Table("Examenes")]
    public class Examen
    {
        [PrimaryKey,AutoIncrement]
        public int CodExmn { get; set; }
        [ForeignKey(typeof(Paciente))]
        public int CodPaci { get; set; }
        [ForeignKey(typeof(Tipo_Examen))]
        public int CodTpEx { get; set; }
        [MaxLength(255)]
        public string Documento { get; set; }
        public DateTime Fecha { get; set; }

        [ManyToOne]
        public Paciente Paciente { get; set; }
        [ManyToOne]
        public Tipo_Examen Tipo { get; set; }
        [OneToMany]
        public List<Examen_Resultado> resultado { get; set; }
    }
}
