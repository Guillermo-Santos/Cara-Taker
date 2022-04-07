﻿using SQLite;

namespace Care_Taker.Models
{
    [Table("Especialidades")]
    public class Especialidad
    {
        [PrimaryKey, AutoIncrement]
        public int CodEspe { get; set; }
        [MaxLength(100)]
        public string Descripcion { get; set; }
    }
}
