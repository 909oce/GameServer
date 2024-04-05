namespace Buffs
{
    internal class DariusNoxianTacticsSlow : IBuffGameScript
    {
        Particle Slow;
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.SLOW,
            BuffAddType = BuffAddType.REPLACE_EXISTING
        };
        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();
        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            StatsModifier.MoveSpeed.PercentBonus -= 0.2f + (0.15f * ownerSpell.CastInfo.SpellLevel);
            StatsModifier.AttackSpeed.PercentBonus -= 0.2f + (0.15f * ownerSpell.CastInfo.SpellLevel);
            unit.AddStatModifier(StatsModifier);
            Slow = AddParticleTarget(ownerSpell.CastInfo.Owner, unit, "Global_Slow.troy", unit, buff.Duration);
        }
        public void OnDeactivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            RemoveParticle(Slow);
        }
    }
}