﻿namespace Buffs
{
    internal class CaitlynEntrapmentMissile : IBuffGameScript
    {
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.SLOW,
            BuffAddType = BuffAddType.STACKS_AND_OVERLAPS,
            MaxStacks = 100,
            IsHidden = true
        };

        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();

        Particle slowParticle;

        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            slowParticle = AddParticleTarget(unit, unit, "caitlyn_entrapment_slow", unit, buff.Duration);
        }

        public void OnDeactivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            RemoveParticle(slowParticle);
        }
    }
}
