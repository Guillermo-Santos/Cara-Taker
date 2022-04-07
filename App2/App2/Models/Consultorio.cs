using SQLite;

namespace Care_Taker.Models
{
    [Table("Consultorios")]
    public class Consultorio
    {
        [PrimaryKey, AutoIncrement]
        public int CodConsul { get; set; }
        [MaxLength(100)]
        public string Descripcion { get; set; }
    }
}
