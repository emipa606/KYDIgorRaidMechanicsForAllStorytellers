using Mlie;
using UnityEngine;
using Verse;

namespace IgorRaidMechanics;

public class IgorRaidMechanicsMod : Mod
{
    public static IgorRaidMechanicsSettings Settings;
    public static string CurrentVersion;

    public IgorRaidMechanicsMod(ModContentPack pack) : base(pack)
    {
        Settings = GetSettings<IgorRaidMechanicsSettings>();
        CurrentVersion = VersionFromManifest.GetVersionFromModMetaData(pack.ModMetaData);
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        base.DoSettingsWindowContents(inRect);
        Settings.DoSettingsWindowContents(inRect);
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