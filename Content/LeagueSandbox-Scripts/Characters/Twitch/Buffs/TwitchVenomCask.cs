namespace Buffs
{
    internal class TwitchVenomCask : IBuffGameScript
    {
        Spell W;
        float T;
        float Damage;
        Particle Cas;
        Particle Tar;
        Particle Red;
        Particle Green;
        ObjAIBase Twitch;
        public BuffScriptMetaData BuffMetaData { get; set; } = new BuffScriptMetaData
        {
            BuffAddType = BuffAddType.REPLACE_EXISTING
        };
        public StatsModifier StatsModifier { get; private set; } = new StatsModifier();

        public void OnActivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            W = ownerSpell;
            Twitch = ownerSpell.CastInfo.Owner as Champion;
            Damage = (35f + (55f * Twitch.Spells[2].CastInfo.SpellLevel) + (Twitch.Stats.AbilityPower.Total * 0.6f)) / 12;
            Cas = AddParticle(Twitch, null, "Twitch_Base_W_cas.troy", unit.Position, buff.Duration, 1);
            Tar = AddParticle(Twitch, null, "Twitch_Base_W_Tar.troy", unit.Position, buff.Duration, 1);
            if (Twitch.Team == TeamId.TEAM_BLUE)
            {
                Red = AddParticle(Twitch, null, "twitch_w_indicator_red_team", unit.Position, lifetime: buff.Duration, teamOnly: TeamId.TEAM_PURPLE);
                Green = AddParticle(Twitch, null, "twitch_w_indicator_green_team", unit.Position, lifetime: buff.Duration, teamOnly: TeamId.TEAM_BLUE);
            }
            else
            {
                Red = AddParticle(Twitch, null, "twitch_w_indicator_red_team", unit.Position, lifetime: buff.Duration, teamOnly: TeamId.TEAM_BLUE);
                Green = AddParticle(Twitch, null, "twitch_w_indicator_green_team", unit.Position, lifetime: buff.Duration, teamOnly: TeamId.TEAM_PURPLE);
            }
        }
        public void OnDeactivate(AttackableUnit unit, Buff buff, Spell ownerSpell)
        {
            RemoveParticle(Cas);
            RemoveParticle(Tar);
            RemoveParticle(Red);
            RemoveParticle(Green);
            unit.Die(CreateDeathData(false, 0, unit, unit, DamageType.DAMAGE_TYPE_TRUE, DamageSource.DAMAGE_SOURCE_INTERNALRAW, 0.0f));
        }
        public void OnUpdate(float diff)
        {
            T += diff;
            if (T >= 0)
            {
                T = -250;
                var units = GetUnitsInRange(Green.Position, 250f, true);
                for (int i = 0; i < units.Count; i++)
                {
                    if (units[i].Team != Twitch.Team && !(units[i] is ObjBuilding || units[i] is BaseTurret))
                    {
                        AddBuff("", 2.5f, 1, W, units[i], Twitch, false);
                        //AddParticleTarget(Twitch, units[i], "MissFortune_Base_E_Unit_Tar", units[i],10);
                        //units[i].TakeDamage(Twitch, damage, DamageType.DAMAGE_TYPE_MAGICAL,DamageSource.DAMAGE_SOURCE_SPELLAOE, false);
                        //AddParticleTarget(Twitch, units[i], "Ekko_Base_W_Shield_HitDodge", units[i]);
                    }
                }
            }
        }
    }
}
