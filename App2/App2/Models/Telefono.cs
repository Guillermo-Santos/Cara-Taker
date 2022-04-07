using SQLite;

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
    }
}
