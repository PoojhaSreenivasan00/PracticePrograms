namespace MyFirstWebApp.Services
{
    //This class is created for dependency injection.
    public interface ILoggerService // Creating interface for dependency injection
    {
        void Log(string message);
    }
    public class LoggerService : ILoggerService
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
