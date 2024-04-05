namespace Spells
{
    public class KatarinaQ : ISpellScript
    {
        Spell QMis;
        float Damage;
        float MarkDamage;
        ObjAIBase Katarina;
        SpellMissile Missile;
        AttackableUnit Target;
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = true
        };
        public void OnSpellPostCast(Spell spell)
        {
            QMis = spell;
            Katarina = spell.CastInfo.Owner as Champion;
            Missile = spell.CreateSpellMissile(new MissileParameters { Type = MissileType.Target });
            ApiEventManager.OnSpellMissileHit.AddListener(this, Missile, TargetExecute, false);
        }
        public void TargetExecute(SpellMissile missile, AttackableUnit target)
        {
            Damage = 45f + (QMis.CastInfo.SpellLevel * 35f) + (Katarina.Stats.AbilityPower.Total * 0.5f);
            target.TakeDamage(Katarina, Damage, DamageType.DAMAGE_TYPE_MAGICAL, DamageSource.DAMAGE_SOURCE_SPELL, false);
            //AddParticleTarget(owner, target, "katarina_bouncingBlades_tar.troy", target);
            AddBuff("KatarinaQMark", 4f, 1, QMis, target, Katarina, false);
            var xx = GetClosestUnitInRange(target, 300, true);
            if (xx != Katarina && !xx.IsDead && xx != null) SpellCast(Katarina, 2, SpellSlotType.ExtraSlots, false, xx, target.Position);
            //if (missile is ISpellChainMissile chainMissile && chainMissile.ObjectsHit.Count > 4) missile.SetToRemove();
        }
    }
    public class KatarinaQMis : ISpellScript
    {
        Spell QMis;
        float Damage;
        float MarkDamage;
        ObjAIBase Katarina;
        SpellMissile Missile;
        AttackableUnit Target;
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            DoesntBreakShields = true,
            TriggersSpellCasts = true,
            IsDamagingSpell = true,
            NotSingleTargetSpell = false,
            PersistsThroughDeath = true,
            SpellDamageRatio = 1.0f,
        };


        public void OnSpellPostCast(Spell spell)
        {
            QMis = spell;
            Katarina = spell.CastInfo.Owner as Champion;
            Missile = spell.CreateSpellMissile(new MissileParameters
            {
                Type = MissileType.Chained,
                MaximumHits = 4,
                CanHitSameTarget = false,
                CanHitSameTargetConsecutively = false
            });
            ApiEventManager.OnSpellMissileHit.AddListener(this, Missile, TargetExecute, false);
        }
        public void TargetExecute(SpellMissile missile, AttackableUnit target)
        {
            //if (firstTarget == target)
            //{
            //    return;
            //}
            AddBuff("KatarinaQMark", 4f, 1, QMis, target, Katarina, false);
            /*var x = GetClosestUnitInRange(target, 600, true);
             if (x.IsDead == false)
             {
                 var owner = spell.CastInfo.Owner;
                 var ap = owner.Stats.AbilityPower.Total * 0.5f;
                 var damage = 45f + spell.CastInfo.SpellLevel * 35f + ap;
                 target.TakeDamage(owner, damage, DamageType.DAMAGE_TYPE_MAGICAL, DamageSource.DAMAGE_SOURCE_SPELL, false);
                 if (bounce != 3)
                 {
                     bounce++;
                     SpellCast(owner, 2, SpellSlotType.ExtraSlots, true, x, target.Position);
                     AddBuff("KatarinaQMark", 4f, 1, spell, target, owner, false);
                 }
                 else
                 {
                     bounce = 0;
                 }
             } */
        }
    }
}
