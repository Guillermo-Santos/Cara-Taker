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
        [ForeignKey(typeof(Persona))]
        public int CodPers { get; set; }
        [ForeignKey(typeof(Tipo_Telefono))]
        public int CodTpTf { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Tipo_Telefono Tipo { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Persona Persona { get; set; }
    }
}
