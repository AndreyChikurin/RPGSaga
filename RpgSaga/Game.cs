namespace RpgSaga
{
    using RpgSaga.Loggers;

    public class Game
    {
        private ILogger _logger;

        public Game(LogType log)
        {
            _logger = log == LogType.LogConsole ? new LoggerForConsole() : new LoggerForFile(@"Logs");
        }

        public enum LogType
        {
            LogConsole,
            LogFile,
        }
    }
}
