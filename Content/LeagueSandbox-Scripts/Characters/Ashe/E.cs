namespace Spells
{
    public class AsheSpiritOfTheHawk : ISpellScript
    {
        Minion Eye;
        Spell Arrow;
        Vector2 Pos;
        ObjAIBase Ashe;
        SpellMissile Missile;
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = true
        };
        public void OnSpellPostCast(Spell spell)
        {
            Arrow = spell;
            Ashe = spell.CastInfo.Owner as Champion;
            Pos = new Vector2(spell.CastInfo.TargetPosition.X, spell.CastInfo.TargetPosition.Z);
            Missile = spell.CreateSpellMissile(new MissileParameters { Type = MissileType.Circle, OverrideEndPosition = Pos });
            ApiEventManager.OnSpellMissileEnd.AddListener(this, Missile, OnMissileEnd, true);
        }
        public void OnMissileEnd(SpellMissile missile)
        {
            Eye = AddMinion(Ashe, "TestCube", "TestCube", missile.Position, Ashe.Team, Ashe.SkinID, true, false);
            AddBuff("AsheSpiritOfTheHawkCast", 5f, 1, Arrow, Eye, Ashe, false);
        }
    }
    public class AsheSpiritOfTheHawkCast : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true,
            IsDamagingSpell = true
        };
    }
}
