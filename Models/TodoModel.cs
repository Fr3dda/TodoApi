namespace TodoApi.Models
{
    public class TodoModel
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public StatusModel Status { get; set; }
        public CustomerModel Customer { get; set; }
        public ICollection<CommentModel> Comments { get; set; }

        

    }
}
