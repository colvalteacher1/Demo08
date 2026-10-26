using System.ComponentModel.DataAnnotations;

namespace Demo08.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        // Relation : un auteur possède plusieurs livres
        public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    }
}
