using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Care_Taker.Models
{
    [Table("Cita_Especilidades")]
    public class Cita_Especialidad
    {
        [PrimaryKey, ForeignKey(typeof(Tipo_Cita))]
        public int CodTpCt { get; set; }
        [PrimaryKey, ForeignKey(typeof(Especialidad))]
        public int CodEspe { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Tipo_Cita Tipo_Cita { get; set; }
        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Especialidad Especialidad { get; set; }
    }
}
