using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace Care_Taker.Models
{
    [Table("Telefonos")]
    public class Telefono
    {
        [PrimaryKey, AutoIncrement]
        public int CodTelf { get; set; }
        [MaxLength(100)]
        public string telefono { get; set; }
        public int CodTpTf { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Tipo_Telefono Tipo { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Telefono_Persona> Personas { get; set; }
    }
}
