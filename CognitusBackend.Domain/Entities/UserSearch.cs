using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CognitusBackend.Domain.Entities
{
    public class UserSearch
    {
        [Key]
        public Guid Id { get; set; }

        [Required, Column(TypeName = "varchar(100)")]
        public string LastSearch { get; set; } = string.Empty;
        [Required]
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; } = null!;
    }
}
