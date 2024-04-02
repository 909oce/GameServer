namespace Buffs
{
    internal class OdinBombSuppressionChaos : IBuffGameScript
    {
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.INTERNAL,
            BuffAddType = BuffAddType.REPLACE_EXISTING
        };

        public StatsModifier StatsModifier { get; private set; }

        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            if (unit.HasBuff("OdinBombSuppressionOrder"))
            {
                buff.DeactivateBuff();
                unit.GetBuffWithName("OdinBombSuppressionOrder").DeactivateBuff();
                StopTargetingUnit(unit);
            }
        }
    }
}
