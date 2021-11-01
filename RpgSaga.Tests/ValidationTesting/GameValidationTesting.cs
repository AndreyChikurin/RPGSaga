namespace RpgSaga.Tests.ValidationTesting
{
    using System.Linq;
    using Xunit;

    public class GameValidationTesting
    {
        [Theory]
        [InlineData("0", "6", "1", null)]
        [InlineData("0", null, "0", null)]
        [InlineData("0", "5", "1", "Incorrect players number")]
        [InlineData("2", "6", "1", "Incorrect log type")]
        [InlineData("as", "as", "1", "Log type was not a numberPlayers number was not a number")]
        [InlineData("2", "5", "1", "Incorrect log typeIncorrect players number")]
        [InlineData("0", null, "as", "GenerationOfPlayers was not a number")]
        [InlineData("0", null, "4", "Incorrect generation of players number")]
        [InlineData("2", null, "as", "Incorrect log typeGenerationOfPlayers was not a number")]
        [InlineData("as", null, "4", "Log type was not a numberIncorrect generation of players number")]

        public void GameValidationTest1(string logger, string playersNumber, string generationOfPlayers, string errorMessage)
        {
            var game = new Game();
            game.Start(logger, playersNumber, generationOfPlayers);
            string result = null;

            game.ErrorMessages.ToList().ForEach(message => result += message);

            Assert.Equal(errorMessage, result);
        }
    }
}