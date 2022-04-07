using SQLite;
using System;

namespace Care_Taker.Models
{
    [Table("Empleados")]
    public class Empleado
    {
        [PrimaryKey, AutoIncrement]
        public int CodEmpl { get; set; }
        public int CodPers { get; set; }
        public int CodPtEm { get; set; }
        public int CodUser { get; set; }
        public DateTime FecEntr { get; set; }
    }
}
