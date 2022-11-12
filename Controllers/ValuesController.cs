using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TodoApi.Models.Entities;
using TodoApi.Models;
using TodoApi.Context;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly DataContext _context;

        public StatusController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(StatusRequest req)
        {
            try
            {
                if (!await _context.Status.AnyAsync(x => x.Status == req.Status))
                {
                    var statusEntity = new StatusEntity { Status = req.Status };
                    _context.Add(statusEntity);
                    await _context.SaveChangesAsync();

                    return new OkObjectResult(statusEntity);
                }

            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var statues = new List<StatusModel>();
                foreach (var status in await _context.Status.ToListAsync())
                    statues.Add(new StatusModel
                    {
                        Id = status.Id,
                        Status = status.Status
                    });

                return new OkObjectResult(statues);
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }
    }
}
