﻿using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace Care_Taker.Models
{
    [Table("Dias")]
    public class Dia
    {
        [PrimaryKey, AutoIncrement]
        public int CodDia { get; set; }
        [MaxLength(100)]
        public string Descripcion { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Turno> Turnos { get; set; }
    }
}
