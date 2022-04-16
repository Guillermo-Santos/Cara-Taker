using System;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace Care_Taker.Models
{
    [Table("Personas")]
    public class Persona
    {
        [PrimaryKey, AutoIncrement]
        public int CodPers { get; set; }
        [MaxLength(100)]
        public string Nombre { get; set; }
        [MaxLength(100)]
        public string Apellidos { get; set; }
        public DateTime FecNaci { get; set; }
        [ForeignKey(typeof(Tipo_Sexo))]
        public int CodSexo { get; set; }

        [ManyToOne]
        public Tipo_Sexo TipoSexo { get; set; }
        [OneToMany]
        public List<Email> Emails { get; set; }
        [OneToMany]
        public List<Telefono_Persona> Telefonos { get; set; }
    }
}
