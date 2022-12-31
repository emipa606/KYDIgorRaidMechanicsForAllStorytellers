using Mlie;
using UnityEngine;
using Verse;

namespace IgorRaidMechanics;

public class IgorRaidMechanicsMod : Mod
{
    public static IgorRaidMechanicsSettings settings;
    public static string currentVersion;

    public IgorRaidMechanicsMod(ModContentPack pack) : base(pack)
    {
        settings = GetSettings<IgorRaidMechanicsSettings>();
        currentVersion = VersionFromManifest.GetVersionFromModMetaData(pack.ModMetaData);
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        base.DoSettingsWindowContents(inRect);
        settings.DoSettingsWindowContents(inRect);
    }

    public override string SettingsCategory()
    {
        return "[KYD] Igor Raid Mechanics for All Storytellers";
    }

    public override void WriteSettings()
    {
        base.WriteSettings();
        DefsAlterer.DoDefsAlter();
    }
}