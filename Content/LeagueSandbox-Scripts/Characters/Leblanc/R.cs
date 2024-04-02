namespace Spells
{
    public class LeblancMimic : ISpellScript
    {
        ObjAIBase Leblanc;
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = true
        };
        public void OnActivate(ObjAIBase owner, Spell spell)
        {
            Leblanc = owner = spell.CastInfo.Owner as Champion;
            ApiEventManager.OnLevelUpSpell.AddListener(this, spell, OnLevelUp, true);
        }
        public void OnLevelUp(Spell spell)
        {
            ApiEventManager.OnSpellCast.AddListener(this, Leblanc.Spells[0], ChangSpell0, false);
            ApiEventManager.OnSpellCast.AddListener(this, Leblanc.GetSpell("LeblancSlide"), ChangSpell1, false);
            ApiEventManager.OnSpellCast.AddListener(this, Leblanc.Spells[2], ChangSpell2, false);
        }
        public void ChangSpell0(Spell spell)
        {
            if (!Leblanc.HasBuff("LeblancSlideM")) { Leblanc.SetSpell("LeblancChaosOrbM", 3, true); }
        }
        public void ChangSpell1(Spell spell)
        {
            if (!Leblanc.HasBuff("LeblancSlideM")) { Leblanc.SetSpell("LeblancSlideM", 3, true); }
        }
        public void ChangSpell2(Spell spell)
        {
            if (!Leblanc.HasBuff("LeblancSlideM")) { Leblanc.SetSpell("LeblancSoulShackleM", 3, true); }
        }
    }
}
