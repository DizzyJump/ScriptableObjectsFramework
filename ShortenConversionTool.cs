using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortenConversionTool : ScriptableObject
{
    public List<string> HashToStringCache;
    public List<string> LenghToStringCache;

    int GetShortHash(double value)
    {
        if(value < 1)
            return 0;
        int log = GetLenght(value);
        int mod = ((log + 2) % 3) + 1;
        int signs_after_comma = 3 - mod;
        if((log - mod) > 0 && signs_after_comma > 0)
        {
            int tmp = (int)System.Math.Floor(value / System.Math.Pow(10, log - mod - signs_after_comma));
            switch(signs_after_comma)
            {
                case 1:
                    return tmp * 100;
                case 2:
                    return tmp * 10;
                default:
                    return tmp;
            }
        }
        else
            return (int)System.Math.Floor(value / System.Math.Pow(10, log - mod));
    }

    public string GetLeft(double value)
    {
        return HashToStringCache[GetShortHash(value)];
    }

    int GetLenght(double value)
    {
        return value > 1 ? (int)System.Math.Floor(System.Math.Log10(value) + 1) : 1;
    }

    public string GetRight(double value)
    {
        int len = GetLenght(value);
        return LenghToStringCache[len<LenghToStringCache.Count?len:LenghToStringCache.Count-1];
    }

    public string GetShort(double value)
    {
        return GetLeft(value) + GetRight(value);
    }
}
