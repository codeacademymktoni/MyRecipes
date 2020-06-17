
namespace MyRecipes.Services.Interfaces
{
    public interface ILogsService
    {
        void Log(string endpoint, string message, int? userId = null);
    }
}
