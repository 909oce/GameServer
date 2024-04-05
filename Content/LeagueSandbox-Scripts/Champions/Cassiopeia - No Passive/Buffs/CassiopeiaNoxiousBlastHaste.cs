﻿namespace Buffs
{
    internal class CassiopeiaNoxiousBlastHaste : IBuffGameScript
    {

        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.HASTE,
            BuffAddType = BuffAddType.STACKS_AND_OVERLAPS,
            MaxStacks = 5
        };

        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();

        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            StatsModifier.MoveSpeed.PercentBonus += 20 / 100.0f;
            unit.AddStatModifier(StatsModifier);
        }
    }
}