using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Care_Taker.Models
{
    [Table("Telefonos_Persona")]
    public class Telefono_Persona
    {
        [ForeignKey(typeof(Persona))]
        public int CodPers { get; set; }
        [ForeignKey(typeof(Telefono))]
        public int CodTelf { get; set; }

        [ManyToOne]
        public Persona Persona { get; set; }
        [ManyToOne]
        public Telefono Telefono { get; set; }
    }
}
