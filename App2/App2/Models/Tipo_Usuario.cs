using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace Care_Taker.Models
{
    [Table("Tipos_Usuario")]
    public class Tipo_Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int CodTpUs { get; set; }
        [MaxLength(100)]
        public string Descripcion { get; set; }

        [OneToMany]
        public List<Usuario> Usuarios { get; set; }
    }
}
