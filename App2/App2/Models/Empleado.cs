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

        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Persona Persona { get; set; }
        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Puesto_Empleado Puesto { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Usuario Usuario { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Cita> Citas { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Horario_Cita> Horario_Citas { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Empleado_Especialidad> Especialidades { get; set; }
    }
}
