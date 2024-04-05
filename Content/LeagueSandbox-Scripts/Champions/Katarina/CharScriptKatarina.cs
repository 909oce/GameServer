namespace CharScripts
{
    public class CharScriptKatarina : ICharScript
    {
        ObjAIBase Katarina;
        AttackableUnit Target;
        public void OnActivate(ObjAIBase owner, Spell spell = null)
        {
            Katarina = owner as Champion;
            ApiEventManager.OnKill.AddListener(this, Katarina, OnKill, false);
        }
        public void OnKill(DeathData Data)        
        {  
            for (byte i = 0; i < 4; i++)
            {
                Katarina.Spells[i].LowerCooldown(15);
            }
        }
    }
}
