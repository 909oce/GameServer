namespace Buffs
{
    internal class OdinBombSuppressionOrder : IBuffGameScript
    {
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.INTERNAL,
            BuffAddType = BuffAddType.REPLACE_EXISTING
        };

        public StatsModifier StatsModifier { get; private set; }

        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            if (unit.HasBuff("OdinBombSuppressionChaos"))
            {
                buff.DeactivateBuff();
                unit.GetBuffWithName("OdinBombSuppressionChaos").DeactivateBuff();
                StopTargetingUnit(unit);
            }
        }
    }
}
