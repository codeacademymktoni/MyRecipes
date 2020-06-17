using MyRecipes.Data;
using MyRecipes.Repository.Interfaces;
using MyRecipes.Services.Interfaces;
using System;

namespace MyRecipes.Services
{
    public class LogsService : ILogsService
    {
        private readonly ILogsRepository logsRepository;

        public LogsService(ILogsRepository logsRepository)
        {
            this.logsRepository = logsRepository;
        }
        public void Log(string endpoint, string message, int? userId = null)
        {
            var log = new Log()
            {
                DateCreated = DateTime.Now,
                Endpoint = endpoint,
                Message = message,
                UserId = userId
            };

            logsRepository.Add(log);
        }
    }
}
