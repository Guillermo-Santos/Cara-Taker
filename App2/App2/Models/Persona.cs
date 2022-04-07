using System;
using SQLite;

namespace Care_Taker.Models
{
    [Table("Personas")]
    public class Persona
    {
        [PrimaryKey, AutoIncrement]
        public int CodPers { get; set; }
        [MaxLength(100)]
        public string Nombre { get; set; }
        [MaxLength(100)]
        public string Apellidos { get; set; }
        public DateTime FecNaci { get; set; }
        public int CodSexo { get; set; }
    }
}
