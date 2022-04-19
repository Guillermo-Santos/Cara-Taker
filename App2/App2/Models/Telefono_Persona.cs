using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Care_Taker.Models
{
    [Table("Telefonos_Persona")]
    public class Telefono_Persona
    {
        [PrimaryKey, ForeignKey(typeof(Persona))]
        public int CodPers { get; set; }
        [PrimaryKey, ForeignKey(typeof(Telefono))]
        public int CodTelf { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Persona Persona { get; set; }
        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Telefono Telefono { get; set; }
    }
}
