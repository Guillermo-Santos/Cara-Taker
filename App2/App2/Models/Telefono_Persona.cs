using SQLite;

namespace Care_Taker.Models
{
    [Table("Telefonos_Persona")]
    public class Telefono_Persona
    {
        public int CodPers { get; set; }
        public int CodTelf { get; set; }
    }
}
