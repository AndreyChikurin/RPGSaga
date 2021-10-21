namespace RpgSaga.Skills
{
    using System;
    using RpgSaga.Interfaces;
    using RpgSaga.Players;

    public class MortalStrike : ISkill
    {
        private decimal damageCoefficient = 1.3m;

        public void SkillAction(Player soursePlayer, Player targetPlayer)
        {
            targetPlayer.Hp -= (int)Math.Round(soursePlayer.Strength * damageCoefficient);
        }
    }
}
