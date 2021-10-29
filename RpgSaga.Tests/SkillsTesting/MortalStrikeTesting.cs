namespace RpgSaga.Tests.SkillsTesting
{
    using System;
    using System.Collections.Generic;
    using RpgSaga.Interfaces;
    using RpgSaga.Loggers;
    using RpgSaga.Players;
    using RpgSaga.Skills;
    using Xunit;

    public class MortalStrikeTesting
    {
        [Fact]
        public void MortalStrikeTest()
        {
            ILogger testLogger = new LoggerForConsole();

            Mage mage1 = new Mage(5, 60, "TestMage1", new List<ISkill> { new MortalStrike(testLogger) });
            Mage mage2 = new Mage(5, 60, "TestMage2", new List<ISkill>());

            int damage = (int)Math.Round(mage1.Strength * 1.3);
            int mage2HP = mage2.Hp - damage;

            mage1.Skills[0].SkillAction(mage1, mage2);

            Assert.Equal(mage2.Hp, mage2HP);
        }
    }
}
