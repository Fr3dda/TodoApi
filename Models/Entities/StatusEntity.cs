using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models.Entities
{
    public class StatusEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Status { get; set; } = null!;
        public ICollection<TodoEntity> Todos { get; set; }
    }
}
