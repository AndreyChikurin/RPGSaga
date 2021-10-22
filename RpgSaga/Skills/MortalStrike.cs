namespace RpgSaga.Skills
{
    using System;
    using RpgSaga.Interfaces;
    using RpgSaga.Logger;
    using RpgSaga.Players;

    public class MortalStrike : ISkill
    {
        private decimal damageCoefficient = 1.3m;

        public void SkillAction(Player soursePlayer, Player targetPlayer)
        {
            int damage = (int)Math.Round(soursePlayer.Strength * damageCoefficient);
            targetPlayer.Hp -= damage;

            Logger.SkillLog(soursePlayer, targetPlayer, $"MortalStrike and deal {damage}");
        }
    }
}
