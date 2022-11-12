using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
    public class StatusRequest
    {
        [Required]
        public string Status { get; set; }
    }
}
