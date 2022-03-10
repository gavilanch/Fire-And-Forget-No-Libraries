using FireAndForgetDemoENG.Entities;
using FireAndForgetDemoENG.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FireAndForgetDemoENG.Controllers
{
    [ApiController]
    [Route("api/people")]
    public class PeopleController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly ILogsRepository logsRepository;

        public PeopleController(ApplicationDbContext context, ILogsRepository logsRepository)
        {
            this.context = context;
            this.logsRepository = logsRepository;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Person person)
        {
            context.Add(person);
            await context.SaveChangesAsync();

            _ = Task.Run(async () =>
             {
                 await logsRepository
                    .SaveLogBackground($"Person with Id {person.Id} and Name {person.Name} inserted.");
             });


            return Ok();
        }
    }
}
