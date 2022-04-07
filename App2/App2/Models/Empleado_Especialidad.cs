using SQLite;

namespace Care_Taker.Models
{
    [Table("Empleado_Especialidades")]
    public class Empleado_Especialidad
    {
        [PrimaryKey, AutoIncrement]
        public int CodEmpl { get; set; }
        public int CodEspe { get; set; }
    }
}
