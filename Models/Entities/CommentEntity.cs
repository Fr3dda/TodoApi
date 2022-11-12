using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models.Entities
{
    public class CommentEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Comment { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public int TodoId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        public TodoEntity Todo { get; set; }
        public CustomerEntity Customer { get; set; }
    }
}
