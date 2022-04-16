using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace Care_Taker.Models
{
    [Table("Tipos_Examen")]
    public class Tipo_Examen
    {
        [PrimaryKey, AutoIncrement]
        public int CodTpEx { get; set; }
        [MaxLength(100)]
        public string Descripcion { get; set; }

    }
}
