using SQLite;

namespace Care_Taker.Models
{
    [Table("Emails")]
    public class Email
    {
        [PrimaryKey, AutoIncrement]
        public int CodEmail { get; set; }
        [MaxLength(100)]
        public string email { get; set; }
        public int CodPers { get; set; }
    }
}
