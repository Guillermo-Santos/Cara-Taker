using SQLite;

namespace Care_Taker.Models
{
    [Table("Puestos_Empleado")]
    public class Puesto_Empleado
    {
        [PrimaryKey, AutoIncrement]
        public int CodPtEm { get; set; }
        [MaxLength(100)]
        public string Descripcion { get; set; }

    }
}
