﻿namespace Buffs
{
    class AsheSpiritOfTheHawkCast : IBuffGameScript
    {
        ObjAIBase Ashe;
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.COMBAT_DEHANCER
        };

        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();

        Particle p;
        Particle p2;

        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            Ashe = ownerSpell.CastInfo.Owner as Champion;
            var units = GetUnitsInRange(unit.Position, 550f, true);
            for (int i = 0; i < units.Count; i++)
            {
                if (units[i].Team != Ashe.Team && !(units[i] is ObjBuilding || units[i] is BaseTurret))
                {
                    AddParticleTarget(Ashe, units[i], "", units[i]);
                }
            }
            AddParticle(Ashe, null, "Ashe_Base_E_tar_explode.troy", unit.Position, 5f, 1);
            AddParticle(Ashe, null, "Ashe_Base_E_tar_linger.troy", unit.Position, 5f, 1);
        }

        public void OnDeactivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            unit.TakeDamage(unit, 100000, DamageType.DAMAGE_TYPE_TRUE, DamageSource.DAMAGE_SOURCE_SPELLAOE, false);
        }
    }
}