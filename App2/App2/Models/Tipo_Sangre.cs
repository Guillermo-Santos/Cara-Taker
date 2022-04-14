using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace Care_Taker.Models
{
    [Table("Tipos_Sangre")]
    public class Tipo_Sangre
    {
        [PrimaryKey, AutoIncrement]
        public int CodTpSg { get; set; }
        [MaxLength(100)]
        public string Descripcion { get; set; }

        [OneToMany]
        public List<Paciente> Pacientes { get; set; }
    }
}
