namespace RpgSaga.Tests.ValidationTesting
{
    using System.Linq;
    using Xunit;

    public class GameValidationTesting
    {
        [Theory]
        [InlineData("0", "6", null)]
        [InlineData("0", "5", "Incorrect players number")]
        [InlineData("2", "6", "Incorrect log type")]
        [InlineData("as", "as", "Log type was not a numberPlayers number was not a number")]
        [InlineData("2", "5", "Incorrect log typeIncorrect players number")]
        public void GameValidationTest1(string logger, string playersNumber, string errorMessage)
        {
            var game = new Game();
            game.Start(logger, playersNumber);
            string result = null;

            game.ErrorMessages.ToList().ForEach(message => result += message);

            Assert.Equal(errorMessage, result);
        }
    }
}