namespace RpgSaga.Tests.ValidationTesting
{
    using Xunit;

    public class GameValidationTesting
    {
        [Fact]
        public void GameValidationTest()
        {
            int numberOfMessages = 0;
            var game = new Game();
            game.Start("0", "2");

            foreach (string errorMessage in game.ErrorMessages)
            {
                numberOfMessages++;
            }

            Assert.True(numberOfMessages == 0);

            game.Start("test", "test");

            foreach (string errorMessage in game.ErrorMessages)
            {
                numberOfMessages++;
            }

            Assert.True(numberOfMessages == 2);

            game.Start("5", "5");

            foreach (string errorMessage in game.ErrorMessages)
            {
                numberOfMessages++;
            }

            Assert.True(numberOfMessages == 4);
        }
    }
}