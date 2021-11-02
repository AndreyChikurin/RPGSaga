namespace RpgSaga.Tests.ValidationTesting
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
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
        [InlineData("", "Data is incorrect format. Model count must be great or equal 2. Health and strenght must be > 0Player creation from JSON file is failed")]
        [InlineData("[{\"class\": \"Mage\",\"name\": \"Oruma\",\"strenght\": 6,\"maxHp\": 70},{\"class\": \"Warrior\",\"name\": \"Hrago\",\"strenght\": 7,\"maxHp\": 65}]", null)]
        [InlineData("[{\"class\": \"Mage\",\"name\": \"Oruma\",\"strenght\": 6,\"maxHp\": 70},{\"class\": \"Warrior\",\"name\": \"Hrago\",\"strenght\": 7,\"maxHp\": -5}]", "Data is incorrect format. Model count must be great or equal 2. Health and strenght must be > 0Player creation from JSON file is failed")]
        [InlineData("[{\"class\": \"Mage\",\"name\": \"Oruma\",\"strenght\": 6,\"maxHp\": 70}]", "Data is incorrect format. Model count must be great or equal 2. Health and strenght must be > 0Player creation from JSON file is failed")]
        [InlineData("{}", "Json is incorrect, check dataPlayer creation from JSON file is failed")]
        public void GameValidationJsonTest(string jsonToString, string errorMessage)
        {
            string directory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName;

            string path = @$"{directory}/JsonForPlayer/Players.json";

            string data = File.ReadAllText(path);

            using (FileStream fs = File.Create(path, 1024))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(jsonToString);
                fs.Write(info);
            }

            var game = new Game();
            game.Start("0", null, "0");
            string result = null;

            game.ErrorMessages.ToList().ForEach(message => result += message);

            using (FileStream fs = File.Create(path, 1024))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(data);
                fs.Write(info);
            }

            Assert.Equal(errorMessage, result);
        }
    }
}