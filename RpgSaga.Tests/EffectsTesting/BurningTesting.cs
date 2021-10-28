namespace RpgSaga.Tests.EffectsTesting
{
    using System.Collections.Generic;
    using RpgSaga.Effects;
    using RpgSaga.Interfaces;
    using RpgSaga.Loggers;
    using RpgSaga.Players;
    using Xunit;

    public class BurningTesting
    {
        [Fact]
        public void BunringTest()
        {
            ILogger testLogger = new LoggerForConsole();

            Mage mage1 = new Mage(5, 60, "TestMage1", new List<ISkill>());
            mage1.Effects.Add(new Burning(testLogger));

            mage1.Effects[0].EffectAction(mage1);

            Assert.Equal(mage1.MaxHp - 2, mage1.Hp);
        }
    }
}
