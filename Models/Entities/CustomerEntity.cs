using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models.Entities
{
    public class CustomerEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<TodoEntity> Todos { get; set; }
        public ICollection<CommentEntity> Comments { get; set; }
    }
}
