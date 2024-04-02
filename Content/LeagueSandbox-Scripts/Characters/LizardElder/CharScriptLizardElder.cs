﻿namespace CharScripts
{
    internal class CharScriptLizardElder : ICharScript
    {
        public void OnActivate(ObjAIBase owner, Spell spell = null)
        {
            AddBuff("GlobalMonsterBuff", 25000.0f, 1, spell, owner, owner, true);
            AddBuff("BlessingoftheLizardElder", 25000.0f, 1, null, owner, owner, true);
        }

        public void OnHitUnit(DamageData data)
        {
            // TODO: Multiply damage in data (currently unsupported).
        }
    }
}
