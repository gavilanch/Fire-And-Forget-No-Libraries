using FireAndForgetDemoENG.Entities;

namespace FireAndForgetDemoENG.Repositories
{
    public interface ILogsRepository
    {
        Task SaveLogBackground(string message);
    }

    public class LogsRepository: ILogsRepository
    {
        private readonly IServiceProvider serviceProvider;

        public LogsRepository(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task SaveLogBackground(string message)
        {
            try
            {
                await using (var scope = serviceProvider.CreateAsyncScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    var log = new Log()
                    {
                        Message = message
                    };
                    // log.Id = 1;
                    await Task.Delay(5000);
                    context.Add(log);
                    Console.WriteLine("The try");
                    await context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("The catch");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
