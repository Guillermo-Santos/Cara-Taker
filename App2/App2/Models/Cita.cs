using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;

namespace Care_Taker.Models
{
    [Table("Citas")]
    public class Cita
    {
        [PrimaryKey, AutoIncrement]
        public int CodCita { get; set; }
        [ForeignKey(typeof(Empleado))]
        public int CodEmpl { get; set; }
        [ForeignKey(typeof(Paciente))]
        public int CodPaci { get; set; }
        [ForeignKey(typeof(Tipo_Cita))]
        public int CodTpCt { get; set; }
        public DateTime Fecha { get; set; }
        public string Resultado { get; set; }
        public bool Status { get; set; }

        [ManyToOne]
        public Paciente Paciente { get; set; }
        [ManyToOne]
        public Empleado Empleado { get; set; }
        [ManyToOne]
        public Tipo_Cita Tipo { get; set; }

        [OneToMany]
        public List<Examen_Resultado> Resultados { get; set; }
        [OneToMany]
        public List<Examen_Cita> examenes_Cita { get; set; }
    }
}