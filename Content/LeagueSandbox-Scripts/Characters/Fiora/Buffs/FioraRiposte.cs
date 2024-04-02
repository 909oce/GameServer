namespace Buffs
{
    internal class FioraRiposte : IBuffGameScript
    {
        Buff Riposte;
        ObjAIBase Fiora;
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffType = BuffType.COMBAT_ENCHANCER,
            BuffAddType = BuffAddType.REPLACE_EXISTING
        };
        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();
        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            Riposte = buff;
            Fiora = ownerSpell.CastInfo.Owner as Champion;
            ApiEventManager.OnTakeDamage.AddListener(this, Fiora, TakeDamage, false);
        }
        public void TakeDamage(DamageData damageData)
        {
            Riposte.DeactivateBuff();
            Fiora.CancelAutoAttack(true);
            damageData.Damage = 0;
            SpellCast(Fiora, 4, SpellSlotType.ExtraSlots, true, damageData.Attacker, Vector2.Zero);
        }
        public void OnDeactivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            if (buff.TimeElapsed >= buff.Duration)
            {
                ApiEventManager.OnTakeDamage.RemoveListener(this);
                //ApiEventManager.OnLaunchAttack.RemoveListener(this);
            }
        }
    }
}
