namespace Spells
{
    public class RaiseMorale : ISpellScript
    {
        public SpellScriptMetadata ScriptMetadata { get; private set; } = new SpellScriptMetadata()
        {
            TriggersSpellCasts = true
        };

        public void OnSpellPostCast(Spell spell)
        {
            var hasbuff = spell.CastInfo.Owner.HasBuff("RaiseMoraleActive");

            if (hasbuff == false)
            {
                AddBuff("RaiseMoraleActive", 7.0f, 1, spell, spell.CastInfo.Owner, spell.CastInfo.Owner);
            }

            var units = GetUnitsInRange(spell.CastInfo.Owner.Position, 1000, true).Where(x => x.Team != CustomConvert.GetEnemyTeam(spell.CastInfo.Owner.Team));

            foreach (var allyTarget in units)
            {
                if (allyTarget is AttackableUnit && spell.CastInfo.Owner != allyTarget && hasbuff == false)
                {
                    AddBuff("RaiseMoraleActive", 7.0f, 1, spell, allyTarget, spell.CastInfo.Owner);
                }
            }
        }
    }
}