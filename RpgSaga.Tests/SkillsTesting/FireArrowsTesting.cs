namespace RpgSaga.Tests.SkillsTesting
{
    using System.Collections.Generic;
    using RpgSaga.Effects;
    using RpgSaga.Interfaces;
    using RpgSaga.Loggers;
    using RpgSaga.Players;
    using RpgSaga.Skills;
    using Xunit;

    public class FireArrowsTesting
    {
        [Fact]
        public void FireArrowsTest()
        {
            ILogger testLogger = new LoggerForConsole();

            Mage mage1 = new Mage(5, 60, "TestMage1", new List<ISkill> { new FireArrows(testLogger) });
            Mage mage2 = new Mage(5, 60, "TestMage2", new List<ISkill>());

            List<IEffect> currentEffect = new List<IEffect>() { new Burning(testLogger) };

            mage1.Skills[0].SkillAction(mage1, mage2);

            Assert.Equal(currentEffect[0], mage2.Effects[0]);
        }
    }
}