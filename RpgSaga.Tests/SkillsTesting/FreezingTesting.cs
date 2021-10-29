namespace RpgSaga.Tests.SkillsTesting
{
    using System.Collections.Generic;
    using RpgSaga.Effects;
    using RpgSaga.Interfaces;
    using RpgSaga.Loggers;
    using RpgSaga.Players;
    using RpgSaga.Skills;
    using Xunit;

    public class FreezingTesting
    {
        [Fact]
        public void FreezingeTest()
        {
            ILogger testLogger = new LoggerForConsole();

            Mage mage1 = new Mage(5, 60, "TestMage1", new List<ISkill> { new Freezing(testLogger) });
            Mage mage2 = new Mage(5, 60, "TestMage2", new List<ISkill>());

            List<IEffect> currentEffect = new List<IEffect>() { new SkipMove(testLogger, 1) };

            mage1.Skills[0].SkillAction(mage1, mage2);

            Assert.Equal(currentEffect[0].GetType(), mage2.Effects[0].GetType());
        }
    }
}