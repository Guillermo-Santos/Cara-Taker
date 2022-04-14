using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;

namespace Care_Taker.Models
{
    [Table("Empleados")]
    public class Empleado
    {
        [PrimaryKey, AutoIncrement]
        public int CodEmpl { get; set; }
        [ForeignKey(typeof(Persona))]
        public int CodPers { get; set; }
        [ForeignKey(typeof(Puesto_Empleado))]
        public int CodPtEm { get; set; }
        [ForeignKey(typeof(Usuario))]
        public int CodUser { get; set; }
        public DateTime FecEntr { get; set; }

        [OneToOne]
        public Persona Persona { get; set; }
        [ManyToOne]
        public Puesto_Empleado Puesto { get; set; }
        [OneToOne]
        public Usuario Usuario { get; set; }
        [OneToMany]
        public List<Cita> Citas { get; set; }
        [OneToMany]
        public List<Horario_Cita> Horario_Citas { get; set; }
    }
}
