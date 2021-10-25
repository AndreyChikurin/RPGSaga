namespace RpgSaga
{
    using RpgSaga.Loggers;

    public class Game
    {
        private ILogger _logger;

        public Game(int log)
        {
            _logger = log == 1 ? new LoggerForConsole() : new LoggerForFile();
        }
    }
}
