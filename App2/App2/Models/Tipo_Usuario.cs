using SQLite;

namespace Care_Taker.Models
{
    [Table("Tipos_Usuario")]
    public class Tipo_Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int CodTpUs { get; set; }
        [MaxLength(100)]
        public string Descripcion { get; set; }
    }
}
