using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using ToDoAppServer.Domain.Enums;

namespace ToDoAppServer.Domain.Entities
{
    [Table("users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public required string FirstName { get; set; }

        [Required] 
        public required string LastName { get;set; }

        [Required]
        public required string Username { get; set; }

        [Required]
        public required string Password { get; set; }

        [Required]
        public required string Email { get; set; }

        [Required]
        [EnumDataType(typeof(UserGender))]
        public required UserGender Gender { get; set; }

        [Required]
        [EnumDataType(typeof(UserRole))]
        public required UserRole Role { get; set; }

        [JsonIgnore]
        public ICollection<Project>? Projects { get; set; }
    }
}
