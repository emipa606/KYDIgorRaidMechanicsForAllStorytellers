using RimWorld;
using VEF.Storyteller;
using Verse;

namespace IgorRaidMechanics;

[StaticConstructorOnStartup]
public static class DefsAlterer
{
    static DefsAlterer()
    {
        DoDefsAlter();
    }

    public static void DoDefsAlter()
    {
        if (IgorRaidMechanicsMod.Settings.FirstTimeInit)
        {
            IgorRaidMechanicsMod.Settings.DamageMultiplier = 2f;
            IgorRaidMechanicsMod.Settings.DisableThreatsAtPopulationCount = 1;
            IgorRaidMechanicsMod.Settings.GoodIncidents =
                IgorRaidMechanicsMod.Settings.BaseGoodIncidents.ListFullCopy();
            IgorRaidMechanicsMod.Settings.FirstTimeInit = false;
            IgorRaidMechanicsMod.Settings.EnableRaidWarning = false;
        }

        foreach (var storytellerDef in DefDatabase<StorytellerDef>.AllDefs)
        {
            var modExtension = storytellerDef.GetModExtension<StorytellerDefExtension>();
            if (modExtension is null)
            {
                modExtension = new StorytellerDefExtension();
                storytellerDef.modExtensions ??= [];

                storytellerDef.modExtensions.Add(modExtension);
            }

            assignValues(ref modExtension);
        }
    }

    private static void assignValues(ref StorytellerDefExtension modExtension)
    {
        modExtension.storytellerThreat = new StorytellerThreat
        {
            allDamagesMultiplier = IgorRaidMechanicsMod.Settings.DamageMultiplier,
            disableThreatsAtPopulationCount = IgorRaidMechanicsMod.Settings.DisableThreatsAtPopulationCount,
            goodIncidents = IgorRaidMechanicsMod.Settings.GoodIncidents
        };
        if (IgorRaidMechanicsMod.Settings.EnableRaidWarning)
        {
            var hour = IgorRaidMechanicsMod.Settings.RaidWarningInterval * 2500;
            modExtension.storytellerThreat.raidWarningRange = new IntRange(hour, hour);
        }
        else
        {
            modExtension.storytellerThreat.raidWarningRange = null;
        }
    }
}