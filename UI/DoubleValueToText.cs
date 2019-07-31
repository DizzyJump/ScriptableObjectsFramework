using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleValueToText : ValueToTextBase
{
    public enum RenderModes
    {
        Normal,
        ShortLeft,
        ShortRight,
        Short,
    }
    public DoubleValue Value;
    public RenderModes Mode = RenderModes.Normal;
    public ShortenConversionTool ShortenTool;

    protected override string _GetValueString()
    {
        switch(Mode)
        {
            case RenderModes.ShortLeft:
                return ShortenTool.GetLeft(Value.Value);
            case RenderModes.ShortRight:
                return ShortenTool.GetRight(Value.Value);
            case RenderModes.Short:
                return ShortenTool.GetShort(Value.Value);
            case RenderModes.Normal:
            default:
                return Value.Value.ToString();
        }
    }
}
