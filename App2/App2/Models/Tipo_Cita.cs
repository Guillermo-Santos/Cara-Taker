using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace Care_Taker.Models
{
    [Table("Tipos_Cita")]
    public class Tipo_Cita
    {
        [PrimaryKey, AutoIncrement]
        public int CodTpCt { get; set; }
        [MaxLength(100)]
        public string Descripcion { get; set; }
        public int Duracion { get; set; }

        [OneToMany]
        public List<Cita> Citas { get; set; }
        [OneToMany]
        public List<Cita_Especialidad> cita_Especialidades { get; set; }
    }
}
