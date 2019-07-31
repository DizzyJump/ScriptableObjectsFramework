using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Convertor
{
    public static string GetShortNumberLeft(double value)
    {
        if(value < 1)
            return "0";
        int log = GetLenght(value);
        int mod = ((log + 2) % 3) + 1;
        int signs_after_comma = 3 - mod;
        double short_val = 0;
        if(log - mod > 0)
        {
            short_val = value / System.Math.Pow(10, log - mod - signs_after_comma);
            double factor = System.Math.Pow(10, signs_after_comma);
            double floored = System.Math.Floor(short_val);
            short_val = floored / factor;
        }
        else
            short_val = System.Math.Floor(value);
        return short_val.ToString();
    }

    public static int GetShortHash2(double value)
    {
        if(value < 1)
            return 0;
        int log = GetLenght(value);
        int mod = ((log + 2) % 3) + 1;
        int signs_after_comma = 3 - mod;
        if((log - mod) > 0 && signs_after_comma > 0)
        {
            int tmp = (int)System.Math.Floor(value/System.Math.Pow(10,log-mod-signs_after_comma));
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

    public static int GetShortHash(double value)
    {
        if(value < 1)
            return 0;
        int log = GetLenght(value);
        int mod = ((log + 2) % 3) + 1;
        int signs_after_comma = 3 - mod;
        double short_val = 0;
        if(log - mod > 0)
        {
            short_val = value / System.Math.Pow(10, log - mod - signs_after_comma);
            double factor = System.Math.Pow(10, signs_after_comma);
            double floored = System.Math.Floor(short_val);
            short_val = floored;
        }
        else
            short_val = System.Math.Floor(value);
        return (int)short_val;
    }

    public static int GetLenght(double value)
    {
        return value > 1 ? (int)System.Math.Floor(System.Math.Log10(value) + 1) : 1;
    }

    public static string GetShortNumberRightFromLenght(int lenth)
    {
        string modifier = "";
        if(lenth <= 84)
            modifier = "gi";
        if(lenth <= 81)
            modifier = "fh";
        if(lenth <= 78)
            modifier = "eg";
        if(lenth <= 75)
            modifier = "df";
        if(lenth <= 72)
            modifier = "ce";
        if(lenth <= 69)
            modifier = "bd";
        if(lenth <= 66)
            modifier = "ac";
        if(lenth <= 63)
            modifier = "hi";
        if(lenth <= 60)
            modifier = "gh";
        if(lenth <= 57)
            modifier = "fg";
        if(lenth <= 54)
            modifier = "ef";
        if(lenth <= 51)
            modifier = "cd";
        if(lenth <= 48)
            modifier = "bc";
        if(lenth <= 45)
            modifier = "ab";
        if(lenth <= 42)
            modifier = "ii";
        if(lenth <= 39)
            modifier = "hh";
        if(lenth <= 36)
            modifier = "gg";
        if(lenth <= 33)
            modifier = "ff";
        if(lenth <= 30)
            modifier = "ee";
        if(lenth <= 27)
            modifier = "dd";
        if(lenth <= 24)
            modifier = "cc";
        if(lenth <= 21)
            modifier = "bb";
        if(lenth <= 18)
            modifier = "aa";
        if(lenth <= 15)
            modifier = "T";
        if(lenth <= 12)
            modifier = "B";
        if(lenth <= 9)
            modifier = "M";
        if(lenth <= 6)
            modifier = "K";
        if(lenth <= 3)
            modifier = "";
        return modifier;
    }

    public static string GetShortNumberRight(double value)
    {
        int lenth = GetLenght(value);
        return GetShortNumberRightFromLenght(lenth);
    }

    public static string GetShortNumber(double value)
    {
        return GetShortNumberLeft(value) + GetShortNumberRight(value);
    }

    public static string ConvertToString(double value)
    {
        string value_str = value.ToString("F0");
        int lenth = value_str.Length;
        if(lenth <= 3)
            return value_str;
        int lenth_mod_3 = lenth % 3;
        if(lenth_mod_3 > 0)
        {
            value_str = value_str.Insert(lenth_mod_3, ",");
            value_str = value_str.Substring(0, 4);
            value_str = value_str.TrimEnd('0');
            if(value_str[value_str.Length - 1] == ',')
                value_str = value_str.TrimEnd(',');
        }
        else
        {
            value_str = value_str.Substring(0, 3);
        }

        //value_str = value_str.Substring(0, 3);
        string modifier = "";
        if(lenth <= 84)
            modifier = "gi";
        if(lenth <= 81)
            modifier = "fh";
        if(lenth <= 78)
            modifier = "eg";
        if(lenth <= 75)
            modifier = "df";
        if(lenth <= 72)
            modifier = "ce";
        if(lenth <= 69)
            modifier = "bd";
        if(lenth <= 66)
            modifier = "ac";
        if(lenth <= 63)
            modifier = "hi";
        if(lenth <= 60)
            modifier = "gh";
        if(lenth <= 57)
            modifier = "fg";
        if(lenth <= 54)
            modifier = "ef";
        if(lenth <= 51)
            modifier = "cd";
        if(lenth <= 48)
            modifier = "bc";
        if(lenth <= 45)
            modifier = "ab";
        if(lenth <= 42)
            modifier = "ii";
        if(lenth <= 39)
            modifier = "hh";
        if(lenth <= 36)
            modifier = "gg";
        if(lenth <= 33)
            modifier = "ff";
        if(lenth <= 30)
            modifier = "ee";
        if(lenth <= 27)
            modifier = "dd";
        if(lenth <= 24)
            modifier = "cc";
        if(lenth <= 21)
            modifier = "bb";
        if(lenth <= 18)
            modifier = "aa";
        if(lenth <= 15)
            modifier = "T";
        if(lenth <= 12)
            modifier = "B";
        if(lenth <= 9)
            modifier = "M";
        if(lenth <= 6)
            modifier = "K";
        value_str += modifier;
        return value_str;
    }
}
