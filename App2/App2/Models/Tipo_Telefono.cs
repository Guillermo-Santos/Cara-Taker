using SQLite;

namespace Care_Taker.Models
{
    [Table("Tipos_Telefono")]
    public class Tipo_Telefono
    {
        [PrimaryKey, AutoIncrement]
        public int CodTpTf { get; set; }
        [MaxLength(100)]
        public string Descripcion { get; set; }
    }
}
