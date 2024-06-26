﻿namespace ItemPassives
{
    public class ItemID_1054 : IItemScript
    {
        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();

        public void OnActivate(ObjAIBase owner)
        {
            StatsModifier.HealthRegeneration.BaseBonus += 1.2f;
            owner.AddStatModifier(StatsModifier);
        }
    }
}
