using ApiASP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiASP.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
		private readonly FirstDBContext _context;
		public ValuesController(FirstDBContext context)
		{			
			_context = context;
		}
		[HttpGet]
		public async Task <ActionResult<IEnumerable<User>>> GetUsersList()
		{
			return Ok(_context.Users.ToList());
		}
		[HttpPost]
		public async Task<ActionResult<IEnumerable<User>>> Add(User user)
		{
			_context.Users.Add(user);
			_context.SaveChanges();
			return Ok();
		}
		[HttpDelete]
		public async Task<ActionResult<IEnumerable<User>>> Delete(User user)
		{
			_context.Users.Remove(user);
			_context.SaveChanges();
			return Ok();
		}
	}
}
