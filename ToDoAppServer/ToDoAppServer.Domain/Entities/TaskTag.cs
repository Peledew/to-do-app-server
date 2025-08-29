using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoAppServer.Domain.Entities
{
    [Table("task_tags")]
    public class TaskTag
    {
        public Task Task { get; set; } = null!;
        public int TaskId { get; set; }

        public Tag Tag { get; set; } = null!;
        public int TagId { get; set; }
    }
}