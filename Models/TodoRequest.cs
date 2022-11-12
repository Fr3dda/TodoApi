using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
    public class TodoRequest
    {
        [Required]
        public string Subject { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int CustomerId { get; set; }
    }
}
