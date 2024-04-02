namespace Buffs
{
    internal class OdinPlayerBuff : IBuffGameScript
    {
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.COMBAT_ENCHANCER,
            BuffAddType = BuffAddType.REPLACE_EXISTING
        };

        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();

        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell = null)
        {
            //TODO: Add 2% mana regeneration per 1% missing mana
            if (unit.Stats.ParType == PrimaryAbilityResourceType.Energy)
            {
                StatsModifier.ManaRegeneration.FlatBonus += 2.0f;
            }
        }
    }
}