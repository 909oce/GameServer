namespace Spells
{
    public class DariusBasicAttack : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = true
        };

        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            if (owner.HasBuff("DariusNoxianTacticsONH"))
            {
                OverrideAnimation(owner, "Spell2", "Attack1");
            }
            else
            {
                OverrideAnimation(owner, "Attack1", "Spell2");
            }
        }
    }
    public class DariusBasicAttack2 : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = true
        };

        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            if (owner.HasBuff("DariusNoxianTacticsONH"))
            {
                OverrideAnimation(owner, "Spell2", "Attack2");
            }
            else
            {
                OverrideAnimation(owner, "Attack2", "Spell2");
            }
        }
    }
    public class DariusCritAttack : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = true
        };

        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            if (owner.HasBuff("DariusNoxianTacticsONH"))
            {
                OverrideAnimation(owner, "Spell2", "Crit");
            }
            else
            {
                OverrideAnimation(owner, "Crit", "Spell2");
            }
        }
    }
}
