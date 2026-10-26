using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo08.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        // Clé étrangère vers Author
        [Required]
        public int AuthorId { get; set; }

        // Relation : chaque livre appartient à un seul auteur
        [ForeignKey(nameof(AuthorId))]
        public virtual Author Author { get; set; } = null!;

    }
}
