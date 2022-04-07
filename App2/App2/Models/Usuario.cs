using SQLite;

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
        public int CodTpUs { get; set; }
    }
}
