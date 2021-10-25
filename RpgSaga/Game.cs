namespace RpgSaga
{
    using RpgSaga.Loggers;

    public class Game
    {
        private ILogger _logger;

        public Game(LogType log)
        {
            _logger = log == 0 ? new LoggerForConsole() : new LoggerForFile("C:\\Users\\andre\\Desktop\\RPG\\rpgsaganetcore\\RpgSaga\\bin\\Debug\\netcoreapp5\\");
            _logger.Test();
        }

        public enum LogType
        {
            LogConsole,
            LogFile,
        }
    }
}
