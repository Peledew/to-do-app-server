using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoAppServer.Domain.Entities
{
    [Table("projects")]
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public required DateTime DueDate { get; set; }

        [ForeignKey("CreatorId")]
        public User? Creator { get; set; }
        public  int? CreatorId { get; set; }
    }
}
