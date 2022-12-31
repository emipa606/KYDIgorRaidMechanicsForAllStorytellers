using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace IgorRaidMechanics;

internal static class SettingsHelper
{
    public static void SliderLabeled(this Listing_Standard ls, string label, ref int val, string format, float min = 0f,
        float max = 100f, string tooltip = null)
    {
        float num = val;
        ls.SliderLabeled(label, ref num, format, min, max, tooltip);
        val = (int)num;
    }

    public static void SliderLabeled(this Listing_Standard ls, string label, ref float val, string format,
        float min = 0f, float max = 1f, string tooltip = null)
    {
        var rect = ls.GetRect(Text.LineHeight);
        var rect2 = rect.LeftPart(0.7f).Rounded();
        var rect3 = rect.RightPart(0.3f).Rounded().LeftPart(0.67f).Rounded();
        var rect4 = rect.RightPart(0.1f).Rounded();
        var anchor = Text.Anchor;
        Text.Anchor = TextAnchor.MiddleLeft;
        Widgets.Label(rect2, label);
        var num = Widgets.HorizontalSlider_NewTemp(rect3, val, min, max, true);
        val = num;
        Text.Anchor = TextAnchor.MiddleRight;
        Widgets.Label(rect4, string.Format(format, val));
        if (!tooltip.NullOrEmpty())
        {
            TooltipHandler.TipRegion(rect, tooltip);
        }

        Text.Anchor = anchor;
        ls.Gap(ls.verticalSpacing);
    }

    public static Rect GetRect(this Listing_Standard listing_Standard, float? height = null)
    {
        return listing_Standard.GetRect(height ?? Text.LineHeight);
    }

    private static void AddRadioList<T>(this Listing_Standard listing_Standard, List<LabeledRadioValue<T>> items,
        ref T val, float? height = null)
    {
        foreach (var labeledRadioValue in items)
        {
            if (Widgets.RadioButtonLabeled(listing_Standard.GetRect(height), labeledRadioValue.Label,
                    EqualityComparer<T>.Default.Equals(labeledRadioValue.Value, val)))
            {
                val = labeledRadioValue.Value;
            }
        }
    }

    private static List<LabeledRadioValue<string>> GenerateLabeledRadioValues(string[] labels)
    {
        var list = new List<LabeledRadioValue<string>>();
        foreach (var text in labels)
        {
            list.Add(new LabeledRadioValue<string>(text, text));
        }

        return list;
    }

    public static Rect LineRectSpilter(this Listing_Standard listing_Standard, out Rect leftHalf,
        float leftPartPct = 0.5f, float? height = null)
    {
        var rect = listing_Standard.GetRect(height);
        leftHalf = rect.LeftPart(leftPartPct).Rounded();
        return rect;
    }

    public static Rect LineRectSpilter(this Listing_Standard listing_Standard, out Rect leftHalf, out Rect rightHalf,
        float leftPartPct = 0.5f, float? height = null)
    {
        var rect = listing_Standard.LineRectSpilter(out leftHalf, leftPartPct, height);
        rightHalf = rect.RightPart(1f - leftPartPct).Rounded();
        return rect;
    }

    public class LabeledRadioValue<T>
    {
        public LabeledRadioValue(string label, T val)
        {
            Label = label;
            Value = val;
        }

        public string Label { get; set; }

        public T Value { get; set; }
    }
}