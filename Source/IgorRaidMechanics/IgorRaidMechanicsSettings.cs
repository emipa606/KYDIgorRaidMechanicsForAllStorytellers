using System.Collections.Generic;
using System.Linq;
using RimWorld;
using UnityEngine;
using Verse;

namespace IgorRaidMechanics;

public class IgorRaidMechanicsSettings : ModSettings
{
    private static Vector2 scrollPosition = Vector2.zero;

    public readonly List<string> BaseGoodIncidents =
    [
        "ResourcePodCrash",
        "PsychicSoothe",
        "SelfTame",
        "AmbrosiaSprout",
        "FarmAnimalsWanderIn",
        "WandererJoin",
        "RefugeePodCrash",
        "ThrumboPasses",
        "MeteoriteImpact",
        "WildManWandersIn"
    ];

    public float DamageMultiplier;
    public int DisableThreatsAtPopulationCount;
    public bool EnableRaidWarning;
    public bool FirstTimeInit = true;
    public List<string> GoodIncidents = [];
    public int RaidWarningInterval;

    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref FirstTimeInit, "firstTimeInit");
        Scribe_Values.Look(ref DamageMultiplier, "damageMultiplier");
        Scribe_Values.Look(ref DisableThreatsAtPopulationCount, "disableThreatsAtPopulationCount");
        Scribe_Values.Look(ref RaidWarningInterval, "raidWarningInterval");
        Scribe_Values.Look(ref EnableRaidWarning, "enableRaidWarning");
        Scribe_Collections.Look(ref GoodIncidents, "goodIncidents");
    }

    public void DoSettingsWindowContents(Rect inRect)
    {
        var goodIncidentsLocal = GoodIncidents.Where(x => DefDatabase<IncidentDef>.GetNamed(x) != null)
            .OrderBy(x => DefDatabase<IncidentDef>.GetNamed(x).label).ToHashSet();
        goodIncidentsLocal.AddRange(BaseGoodIncidents);
        var allIncidents = DefDatabase<IncidentDef>.AllDefs.Where(x => !GoodIncidents.Contains(x.defName))
            .OrderBy(x => x.label).ToList();
        var rect = new Rect(inRect.x, inRect.y, inRect.width, inRect.height);
        var rect2 = new Rect(0f, 0f, inRect.width - 30f,
            280 + (goodIncidentsLocal.Count * 24) + (allIncidents.Count * 24));
        Widgets.BeginScrollView(rect, ref scrollPosition, rect2);
        var listingStandard = new Listing_Standard();
        listingStandard.Begin(rect2);
        if (listingStandard.ButtonText("Reset".Translate()))
        {
            FirstTimeInit = true;
            DefsAlterer.DoDefsAlter();
        }

        listingStandard.SliderLabeled("Igor.AdjustDamageMultiplier".Translate(), ref DamageMultiplier,
            DamageMultiplier.ToStringDecimalIfSmall(), 0.1f, 5f);
        listingStandard.SliderLabeled("Igor.AdjustMinPopulationForThreats".Translate(),
            ref DisableThreatsAtPopulationCount, DisableThreatsAtPopulationCount.ToString(), 0, 99);
        listingStandard.CheckboxLabeled("Igor.EnableRaidWarning".Translate(), ref EnableRaidWarning);
        if (EnableRaidWarning)
        {
            listingStandard.SliderLabeled("Igor.AdjustRaidWarningInterval".Translate(), ref RaidWarningInterval,
                RaidWarningInterval.ToString(), 0, 24);
        }

        listingStandard.Label("Igor.PickGoodIncidentToFire".Translate());
        if (IgorRaidMechanicsMod.CurrentVersion != null)
        {
            listingStandard.Gap();
            GUI.contentColor = Color.gray;
            listingStandard.Label("Igor.CurrentModVersion".Translate(IgorRaidMechanicsMod.CurrentVersion));
            GUI.contentColor = Color.white;
        }

        listingStandard.GapLine();
        foreach (var incident in goodIncidentsLocal)
        {
            var test = GoodIncidents.Contains(incident);
            listingStandard.CheckboxLabeled(DefDatabase<IncidentDef>.GetNamed(incident).label, ref test);
            if (!test)
            {
                GoodIncidents.Remove(incident);
            }
            else if (!GoodIncidents.Contains(incident))
            {
                GoodIncidents.Add(incident);
            }
        }

        listingStandard.Gap();
        foreach (var incident in allIncidents)
        {
            var test = false;
            listingStandard.CheckboxLabeled(incident.label, ref test);
            if (test)
            {
                GoodIncidents.Add(incident.defName);
            }
        }


        listingStandard.End();
        Widgets.EndScrollView();
        Write();
    }
}