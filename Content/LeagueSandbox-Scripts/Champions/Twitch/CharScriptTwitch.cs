namespace CharScripts
{
    public class CharScriptTwitch : ICharScript
    {
        Spell Passive;
        ObjAIBase Twitch;
        AttackableUnit Target;
        public void OnActivate(ObjAIBase owner, Spell spell = null)
        {
            Passive = spell;
            Twitch = owner as Champion;
            ApiEventManager.OnHitUnit.AddListener(this, Twitch, OnHitUnit, false);
            if (Twitch != null)
            {
                //AddBuff("EkkoRInvuln", 25000f, 1, Twitch.Spells[3], Twitch, Twitch);        		
            }
        }
        public void OnHitUnit(DamageData damageData)
        {
            //if (!damageData.Target.HasBuff("EkkoPassiveSlow"))
            //{    		
            AddBuff("TwitchDeadlyVenom", 6f, 1, Passive, damageData.Target, Twitch);
            //}           			
        }
    }
}
