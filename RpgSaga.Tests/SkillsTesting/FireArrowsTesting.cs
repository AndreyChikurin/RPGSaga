namespace RpgSagaLib.Tests.SkillsTesting
{
    using System.Collections.Generic;
    using RpgSagaLib.Effects;
    using RpgSagaLib.Interfaces;
    using RpgSagaLib.Loggers;
    using RpgSagaLib.Players;
    using RpgSagaLib.Skills;
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

            Assert.True(mage1.Skills[0].SkillCanBeUsed);

            mage1.Skills[0].SkillAction(mage1, mage2);

            Assert.True(!mage1.Skills[0].SkillCanBeUsed);
            Assert.Equal(currentEffect[0].GetType(), mage2.Effects[0].GetType());
        }
    }
}