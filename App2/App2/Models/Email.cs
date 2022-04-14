using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Care_Taker.Models
{
    [Table("Emails")]
    public class Email
    {
        [PrimaryKey, AutoIncrement]
        public int CodEmail { get; set; }
        [MaxLength(100)]
        public string email { get; set; }
        [ForeignKey(typeof(Persona))]
        public int CodPers { get; set; }

        [ManyToOne]
        public Persona Persona { get; set; }
    }
}
