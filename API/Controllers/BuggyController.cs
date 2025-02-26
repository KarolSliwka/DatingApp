using API.Data;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController(DataContext context) : BaseApiController
    {
        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetAuth()
        {
            return "secret text";
        }

        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {
            var thing = context.Users.Find(Guid.NewGuid());
            if (thing == null) return NotFound();
            return thing;
        }

        [HttpGet("server-error")] // errors = 500 server error
        public ActionResult<AppUser> GetServerError()
        {
            var thing = context.Users.Find(Guid.NewGuid()) ?? throw new Exception("A bad thing has happend");
            // null hasn't got toString method
            return thing;
        }

        [HttpGet("bad-request")] // user errors = 400 bad request (400 to 499 range User errors)
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("This was not a good request");
        }
    }
}