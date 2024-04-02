namespace Buffs
{
    internal class HowlingAbyssFBHeal : IBuffGameScript
    {
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.HEAL,
            BuffAddType = BuffAddType.REPLACE_EXISTING,
            IsHidden = true
        };

        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();

        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            unit.Stats.CurrentHealth += 94 + (13 * (unit.Stats.Level - 1));
            unit.Stats.CurrentMana += 90 + (14 * (unit.Stats.Level - 1));
            AddParticleTarget(unit, unit, "odin_healthpackheal", unit);
            AddParticleTarget(unit, unit, "summoner_mana", unit);
        }
    }
}

