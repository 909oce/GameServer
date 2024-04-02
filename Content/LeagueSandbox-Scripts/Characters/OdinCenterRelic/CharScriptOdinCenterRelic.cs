namespace CharScripts
{
    internal class CharScriptOdinCenterRelic : ICharScript
    {
        public void OnActivate(ObjAIBase owner, Spell spell = null)
        {
            SetStatus(owner, StatusFlags.MagicImmune, true);
            SetStatus(owner, StatusFlags.PhysicalImmune, true);
            SetStatus(owner, StatusFlags.CanAttack, false);
            SetStatus(owner, StatusFlags.CanMove, false);

            AddBuff("OdinBombBuff", 25000.0f, 1, null, owner, owner, false);
        }
    }
}
