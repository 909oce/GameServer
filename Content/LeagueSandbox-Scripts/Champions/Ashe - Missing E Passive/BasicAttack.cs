namespace Spells
{
    public class AsheBasicAttack : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = true,
            MissileParameters = new MissileParameters { Type = MissileType.Target }
        };

        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            if (owner.HasBuff("FrostShot"))
            {
                OverrideAnimation(owner, "Spell1", "Attack1");
            }
            else
            {
                OverrideAnimation(owner, "Attack1", "Spell1");
            }
        }
    }
    public class AsheBasicAttack2 : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = true,
            MissileParameters = new MissileParameters { Type = MissileType.Target }
        };

        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            if (owner.HasBuff("FrostShot"))
            {
                OverrideAnimation(owner, "Spell1", "Attack2");
            }
            else
            {
                OverrideAnimation(owner, "Attack2", "Spell1");
            }
        }
    }
    public class AsheCritAttack : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = true,
            MissileParameters = new MissileParameters { Type = MissileType.Target }
        };

        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            if (owner.HasBuff("FrostShot"))
            {
                OverrideAnimation(owner, "Spell1", "Crit");
            }
            else
            {
                OverrideAnimation(owner, "Crit", "Spell1");
            }
        }
    }
}
