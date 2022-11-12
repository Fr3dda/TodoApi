using TodoApi.Context;
using TodoApi.Models;
using TodoApi.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Xml.Linq;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly DataContext _context;

        public TodosController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(TodoRequest req)
        {
            try
            {
                var datetime = DateTime.Now;
                var todoEntity = new TodoEntity
                {
                    Subject = req.Subject,
                    Description = req.Description,
                    CustomerId = req.CustomerId,
                    Created = datetime,
                    Modified = datetime,
                    StatusId = 1
                };

                _context.Add(todoEntity);
                await _context.SaveChangesAsync();

                return new OkObjectResult(todoEntity);
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var todos = new List<TodoModel>();
                foreach (var todoEntity in await _context.Todos.Include(x => x.Status).Include(x => x.Customer).ToListAsync())
                    todos.Add(new TodoModel
                    {
                        Id = todoEntity.Id,
                        Subject = todoEntity.Subject,
                        Description = todoEntity.Description,
                        Created = todoEntity.Created,
                        Modified = todoEntity.Modified,
                        Status = new StatusModel
                        {
                            Id = todoEntity.Status.Id,
                            Status = todoEntity.Status.Status
                        },
                        Customer = new CustomerModel
                        {
                            Id = todoEntity.Customer.Id,
                            FirstName = todoEntity.Customer.FirstName,
                            LastName = todoEntity.Customer.LastName,
                            Email = todoEntity.Customer.Email,
                            PhoneNumber = todoEntity.Customer.PhoneNumber
                        }
                    });

                return new OkObjectResult(todos);
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var todoEntity = await _context.Todos.Include(x => x.Status).Include(x => x.Customer).Include(x => x.Comments).FirstOrDefaultAsync(x => x.Id == id);
                if (todoEntity != null)
                {
                    var comments = new List<CommentModel>();
                    foreach (var comment in todoEntity.Comments)
                        comments.Add(new CommentModel
                        {
                            Id = comment.Id,
                            Comment = comment.Comment,
                            Created = comment.Created,
                            CustomerId = comment.CustomerId
                        });

                    return new OkObjectResult(new TodoModel
                    {
                        Id = todoEntity.Id,
                        Subject = todoEntity.Subject,
                        Description = todoEntity.Description,
                        Created = todoEntity.Created,
                        Modified = todoEntity.Modified,
                        Status = new StatusModel
                        {
                            Id = todoEntity.Status.Id,
                            Status = todoEntity.Status.Status
                        },
                        Customer = new CustomerModel
                        {
                            Id = todoEntity.Customer.Id,
                            FirstName = todoEntity.Customer.FirstName,
                            LastName = todoEntity.Customer.LastName,
                            Email = todoEntity.Customer.Email,
                            PhoneNumber = todoEntity.Customer.PhoneNumber
                        },
                        Comments = comments
                    });
                }


            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }
    }
}