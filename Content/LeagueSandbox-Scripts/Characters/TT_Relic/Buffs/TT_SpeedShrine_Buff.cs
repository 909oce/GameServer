namespace Buffs
{
    internal class TT_SpeedShrine_Buff : IBuffGameScript
    {
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.HASTE,
            BuffAddType = BuffAddType.REPLACE_EXISTING
        };

        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();

        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            //TODO: Make it decay over the duration of the buff
            StatsModifier.MoveSpeed.PercentBonus += 0.2f;
            unit.AddStatModifier(StatsModifier);
        }
    }
}

