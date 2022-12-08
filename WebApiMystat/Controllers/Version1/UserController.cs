using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiMystat.Models;
using WebApiMystat.Serveces;

namespace WebApiMystat.Controllers.Version1;

[ApiController]
[Route("api/v1/{controller}")]
public class UserController : Controller
{
    private readonly MyStatDbContext _myStatDbContext;
    
    [HttpGet("get/{id:int}")]
    public async Task<User?> Get(int id)
    {
        return await _myStatDbContext.Users.SingleOrDefaultAsync(u => u.Id == id);
    }
    [HttpGet("get")]
    public async Task<IEnumerable<User>> Get()
    {
        return await _myStatDbContext.Users.ToListAsync();
    }

    [HttpPost("Add/User")]
    public async Task<HttpResponseMessage> Add(User? user)
    {
        if (user == null)
        {
            return new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
            };
        }

        await _myStatDbContext.Users.AddAsync(user);

        return new HttpResponseMessage()
        {
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }
}