namespace Buffs
{
    internal class FioraFlurryDummy : IBuffGameScript
    {
        ObjAIBase Fiora;
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.COMBAT_ENCHANCER,
            BuffAddType = BuffAddType.STACKS_AND_RENEWS,
            MaxStacks = 3
        };
        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();
        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            Fiora = ownerSpell.CastInfo.Owner as Champion;
            Fiora.RemoveStatModifier(StatsModifier);
            StatsModifier.AttackSpeed.PercentBonus = StatsModifier.MoveSpeed.PercentBonus += (0.05f + (Fiora.Spells[2].CastInfo.SpellLevel * 0.02f)) * buff.StackCount;
            Fiora.AddStatModifier(StatsModifier);
        }
    }
}