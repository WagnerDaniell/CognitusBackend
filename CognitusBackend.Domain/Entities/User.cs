using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CognitusBackend.Domain.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required,Column(TypeName = "varchar(100)")]
        public string Name { get; set; } = string.Empty;
        [Required, Column(TypeName = "varchar(100)")]
        public string Email { get; set; } = string.Empty;
        [Required, Column(TypeName = "varchar(150)")]
        public string Password { get; set; } = string.Empty;
        [Required, Column(TypeName = "varchar(100)")]
        public string Schooling { get; set; } = string.Empty;


        public ICollection<UserSearch> UserSearches { get; set; } = null!;
    }
}
