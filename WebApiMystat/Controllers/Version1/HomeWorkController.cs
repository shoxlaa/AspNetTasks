using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiMystat.Models;
using WebApiMystat.Serveces;

namespace WebApiMystat.Controllers.Version1;

[ApiController]
[Route("api/v1/{controller}")]
public class HomeWorkController : Controller
{
    private readonly MyStatDbContext _userDbContext;

    public HomeWorkController(MyStatDbContext userDbContext)
    {
        _userDbContext = userDbContext;
    }
    [HttpGet("get/{id:int}")]
    public async Task<User?> Get(int id)
    {
        return await _userDbContext.Users.SingleOrDefaultAsync(u => u.Id == id);
    }
    [HttpGet("get")]
    public async Task<IEnumerable<HomeWork>> Get()
    {
        return await _userDbContext.HomeWorks.ToListAsync();
    }

    [HttpPost("add/User")]
    public async Task<HttpResponseMessage> Add(User user)
    {
        if (user == null)
        {
            return new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
            };
        }

        await _userDbContext.Users.AddAsync(user);

        return new HttpResponseMessage()
        {
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }
}