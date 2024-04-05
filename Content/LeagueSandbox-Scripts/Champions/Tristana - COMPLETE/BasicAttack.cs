namespace Spells
{
    public class TristanaBasicAttack : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = true,
            MissileParameters = new MissileParameters { Type = MissileType.Target }
        };

        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            if (owner.HasBuff("RapidFire"))
            {
                OverrideAnimation(owner, "Spell1", "Attack1");
            }
            else
            {
                OverrideAnimation(owner, "Attack1", "Spell1");
            }
        }
    }
    public class TristanaBasicAttack2 : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = true,
            MissileParameters = new MissileParameters { Type = MissileType.Target }
        };

        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            if (owner.HasBuff("RapidFire"))
            {
                OverrideAnimation(owner, "Spell1", "Attack2");
            }
            else
            {
                OverrideAnimation(owner, "Attack2", "Spell1");
            }
        }
    }
    public class TristanaCritAttack : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = true,
            MissileParameters = new MissileParameters { Type = MissileType.Target }
        };

        public void OnSpellPreCast(ObjAIBase owner, Spell spell, AttackableUnit target, Vector2 start, Vector2 end)
        {
            if (owner.HasBuff("RapidFire"))
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