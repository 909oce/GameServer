﻿namespace Buffs
{
    internal class RegenerationPotion : IBuffGameScript
    {
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.HEAL,
            BuffAddType = BuffAddType.STACKS_AND_CONTINUE,
            MaxStacks = 5
        };

        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();

        Particle potion;

        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            var caster = ownerSpell.CastInfo.Owner;
            StatsModifier.HealthRegeneration.FlatBonus = 10f;
            unit.AddStatModifier(StatsModifier);
            potion = AddParticleTarget(caster, unit, "GLOBAL_Item_HealthPotion", unit, buff.Duration, bone: "Buffbone_Glb_Ground_Loc");
        }

        public void OnDeactivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            potion.SetToRemove();
        }
    }
}
