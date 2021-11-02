namespace RpgSaga.Tests.ValidationTesting
{
    using System.Linq;
    using RpgSaga.Deserialize;
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

        [Theory]
        [InlineData("", "Data is incorrect format. Model count must be great or equal 2. Health and strenght must be > 0")]
        [InlineData(null, "Data is incorrect format. Model count must be great or equal 2. Health and strenght must be > 0")]
        [InlineData("[{\"class\": \"Mage\",\"name\": \"Oruma\",\"strenght\": 6,\"maxHp\": 70},{\"class\": \"Warrior\",\"name\": \"Hrago\",\"strenght\": 7,\"maxHp\": 65}]", "")]
        [InlineData("[{\"class\": \"Mage\",\"name\": \"Oruma\",\"strenght\": 6,\"maxHp\": 70},{\"class\": \"Warrior\",\"name\": \"Hrago\",\"strenght\": 7,\"maxHp\": -5}]", "Data is incorrect format. Model count must be great or equal 2. Health and strenght must be > 0")]
        [InlineData("[{\"class\": \"Mage\",\"name\": \"Oruma\",\"strenght\": 6,\"maxHp\": 70}]", "Data is incorrect format. Model count must be great or equal 2. Health and strenght must be > 0")]
        [InlineData("{}", "Json is incorrect, check data")]
        public void GameValidationJsonTest(string jsonToString, string errorMessage)
        {
            var deserializePlayer = new DeserializePlayer();
            string result = deserializePlayer.DeserializePlayerFromJsonTesting(jsonToString);

            Assert.Equal(errorMessage, result);
        }
    }
}