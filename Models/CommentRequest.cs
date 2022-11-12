using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
    public class CommentRequest
    {
        [Required]
        public string Comment { get; set; }

        [Required]
        public int TodoId { get; set; }

        [Required]
        public int CustomerId { get; set; }
    }
}
