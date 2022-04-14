using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Care_Taker.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int CodUser { get; set; }
        [MaxLength(20)]
        public string UserName { get; set; }
        [MaxLength(30)]
        public string Password { get; set; }
        [ForeignKey(typeof(Tipo_Usuario))]
        public int CodTpUs { get; set; }

        [ManyToOne]
        public Tipo_Usuario Tipo_Usuario { get; set; }
        [OneToOne]
        public Paciente Paciente { get; set; }
        [OneToOne]
        public Empleado Empleado { get; set; }
    }
}
