namespace RpgSaga.Tests.EffectsTesting
{
    using System.Collections.Generic;
    using RpgSaga.Effects;
    using RpgSaga.Interfaces;
    using RpgSaga.Loggers;
    using RpgSaga.Players;
    using Xunit;

    public class SkipMoveTesting
    {
        [Fact]
        public void SkipMoveTest()
        {
            ILogger testLogger = new LoggerForConsole();

            Mage mage1 = new Mage(5, 60, "TestMage1", new List<ISkill>());
            Mage mage2 = new Mage(5, 60, "TestMage2", new List<ISkill>());
            mage1.Effects.Add(new SkipMove(testLogger, 1));

            Assert.True(mage1.Effects[0].Duration == 1);

            mage1.Effects[0].EffectAction(mage1);

            Assert.True(mage1.Effects[0].Duration == 0);
        }
    }
}
