using Microsoft.EntityFrameworkCore;
using TodoApi.Models.Entities;

namespace TodoApi.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<StatusEntity> Status { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<TodoEntity> Todos { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }

    }
}
