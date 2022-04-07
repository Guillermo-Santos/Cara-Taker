using SQLite;

namespace Care_Taker.Models
{
    [Table("Tipos_Sexo")]
    public class Tipo_Sexo
    {
        [PrimaryKey, AutoIncrement]
        public int CodSexo { get; set; }
        [MaxLength(100)]
        public string Descripcion { get; set; }
    }
}
