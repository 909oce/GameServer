﻿namespace Talents
{
    internal class Talent_4312 : ITalentScript
    {
        public void OnActivate(ObjAIBase owner, byte rank)
        {
            var movSpeed = new StatsModifier();
            movSpeed.MoveSpeed.PercentBonus = 0.05f * rank;
            owner.AddStatModifier(movSpeed);
        }
    }
}
