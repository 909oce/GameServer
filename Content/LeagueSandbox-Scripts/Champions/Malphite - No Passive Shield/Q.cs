namespace Spells
{
    public class SeismicShard : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata => new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = true,
            MissileParameters = new MissileParameters
            {
                Type = MissileType.Target
            }
        };

        public void OnActivate(ObjAIBase owner, Spell spell)
        {
            ApiEventManager.OnSpellHit.AddListener(this, spell, TargetExecute, false);
        }

        public void TargetExecute(Spell spell, AttackableUnit target, SpellMissile missile, SpellSector sector)
        {
            var owner = spell.CastInfo.Owner as Champion;
            var APratio = owner.Stats.AbilityPower.Total*0.6f;
            var damage = 70*spell.CastInfo.SpellLevel  + APratio;

            AddParticleTarget(owner, target, "Malphite_Base_SeismicShard_mis.troy", target, 1f);
            target.TakeDamage(owner, damage, DamageType.DAMAGE_TYPE_MAGICAL, DamageSource.DAMAGE_SOURCE_SPELL, false);
            AddBuff("Slow", 3f, 1, spell, target, owner);
        }

    }
}