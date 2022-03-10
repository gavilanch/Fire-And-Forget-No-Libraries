using FireAndForgetDemoENG.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FireAndForgetDemoENG.Controllers
{
    [ApiController]
    [Route("api/people")]
    public class PeopleController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public PeopleController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Person person)
        {
            context.Add(person);
            await context.SaveChangesAsync();

            var log = new Log() { Message = $"Person with Id {person.Id} and Name {person.Name} inserted." };
            context.Add(log);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
