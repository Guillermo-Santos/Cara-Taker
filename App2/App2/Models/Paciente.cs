using SQLite;

namespace Care_Taker.Models
{
    [Table("Pacientes")]
    public class Paciente
    {
        [PrimaryKey, AutoIncrement]
        public int CodPaci { get; set; }
        public int CodPers { get; set; }
        public int CodTpSg { get; set; }
        public int CodUser { get; set; }
    }
}