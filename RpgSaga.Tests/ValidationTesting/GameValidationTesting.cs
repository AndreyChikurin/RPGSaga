namespace RpgSaga.Tests.ValidationTesting
{
    using System.Linq;
    using Xunit;

    public class GameValidationTesting
    {
        [Fact]
        public void GameValidationTest()
        {
            var game = new Game();
            game.Start("0", "2");

            Assert.True(game.ErrorMessages.ToList().Count() == 0);

            game.Start("test", "test");

            Assert.True(game.ErrorMessages.ToList()[0] == "Log type was not a number");
            Assert.True(game.ErrorMessages.ToList()[1] == "Players number was not a number");

            game.Start("5", "5");

            Assert.True(game.ErrorMessages.ToList()[0] == "Incorrect log type");
            Assert.True(game.ErrorMessages.ToList()[1] == "incorrect players number");

            game.Start("0", "5");

            Assert.True(game.ErrorMessages.ToList()[0] == "incorrect players number");

            game.Start("2", "6");

            Assert.True(game.ErrorMessages.ToList()[0] == "Incorrect log type");
        }
    }
}