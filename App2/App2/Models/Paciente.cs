using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace Care_Taker.Models
{
    [Table("Pacientes")]
    public class Paciente
    {
        [PrimaryKey, AutoIncrement]
        public int CodPaci { get; set; }
        [ForeignKey(typeof(Persona))]
        public int CodPers { get; set; }
        [ForeignKey(typeof(Tipo_Sangre))]
        public int CodTpSg { get; set; }
        [ForeignKey(typeof(Usuario))]
        public int CodUser { get; set; }

        [OneToOne]
        public Persona Persona { get; set; }
        [ManyToOne]
        public Tipo_Sangre TipoSangre { get; set; }
        [OneToOne]
        public Usuario Usuario { get; set; }
        [OneToMany]
        public List<Examen> examenes { get; set; }
    }
}