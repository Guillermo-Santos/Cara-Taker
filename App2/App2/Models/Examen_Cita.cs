﻿using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Care_Taker.Models
{
    [Table("Examenes_Cita")]
    public class Examen_Cita
    {
        [PrimaryKey, ForeignKey(typeof(Cita))]
        public int CodCita { get; set; }
        [PrimaryKey, ForeignKey(typeof(Tipo_Examen))]
        public int CodTpEx { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Cita Cita { get; set; }
        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Tipo_Examen TipoExamen { get; set; }
    }
}
