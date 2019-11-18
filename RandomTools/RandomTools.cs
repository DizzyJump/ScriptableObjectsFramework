using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTools
{
    System.Random sys_rnd = new System.Random();
    System.Collections.Generic.Stack<double> NormalValues = new System.Collections.Generic.Stack<double>();
    System.Security.Cryptography.RNGCryptoServiceProvider crypto_rnd = new System.Security.Cryptography.RNGCryptoServiceProvider();

    /// <summary>
    /// возвращает случайное число (равномерное распределение) в диапазоне от min до max (не включая max!)
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public int GetRandomInt(int min, int max)
    {
        return sys_rnd.Next(min, max);
    }

    public ulong GetRandomULONG()
    {
        byte[] bytes = new byte[8];
        crypto_rnd.GetBytes(bytes);
        ulong result = 0;
        for(int i = 0; i < 8; i++)
        {
            int offset = 64 - 8 * (i + 1);
            result = result | (((ulong)bytes[i]) << offset);
        }
        return result;
    }

    public ulong GetRandomULONG_Fast()
    {
        byte[] bytes = new byte[8];
        sys_rnd.NextBytes(bytes);
        ulong result = 0;
        for(int i = 0; i < 8; i++)
        {
            int offset = 64 - 8 * (i + 1);
            result = result | (((ulong)bytes[i]) << offset);
        }
        return result;
    }

    /// <summary>
    /// возвращает случайно число (равномерно распределенное) в диапазоне от 0f до 1f
    /// </summary>
    /// <returns></returns>
    public float GetRandomFloat()
    {
        return (float)GetRandomDouble();
    }

    /// <summary>
    /// возвращает случайно число (равномерно распределенное) в диапазоне от min до max
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public float Range(float min, float max)
    {
        return min + (float)GetRandomDouble() * (max - min);
    }

    public double GetRandomDouble()
    {
        return sys_rnd.NextDouble();
    }

    /// <summary>
    /// возвращает случайно число (равномерно распределенное) в диапазоне от -1f до 1f
    /// </summary>
    /// <returns></returns>
    public double GetRandomFloatPosNeg()
    {
        return GetRandomDouble() * 2f - 1f;
    }

    /// <summary>
    /// возвращает случайно число (нормальное распределение)
    /// </summary>
    /// <returns></returns>
    public double NormalDistribution()
    {
        if(NormalValues.Count > 0)
            return NormalValues.Pop();
        double u = 0;
        double v = 0;
        double s = 0;
        do
        {
            u = GetRandomFloatPosNeg();
            v = GetRandomFloatPosNeg();
            s = u * u + v * v;
        } while(s > 1.0 || s == 0.0);
        double r = Math.Sqrt(-2 * Math.Log(s) / s);
        NormalValues.Push(r * u);
        return r * v;
    }

    /// <summary>
    /// возвращает случайно число (нормальное распределение) с матожиданием mean и среднеквадратичным отклонением dev
    /// </summary>
    /// <param name="mean"></param>
    /// <param name="dev"></param>
    /// <returns></returns>
    public double NormalDistribution(float mean, float dev)
    {
        return NormalDistribution() * dev + mean;
    }

    /// <summary>
    /// возвращает случайно число (нормальное распределение) от 0 до 1 с матожиданием 0.5
    /// </summary>
    /// <returns></returns>
    public double NormalDistribution01()
    {
        return Clamp01(NormalDistribution() / 6.0 + 0.5);
    }

    /// <summary>
    /// возвращает случайно число (нормальное распределение) от -1 до 1 с матожиданием 0
    /// </summary>
    /// <returns></returns>
    public double NormalDistribution11()
    {
        return Clamp(NormalDistribution() / 3.0, -1, 1);
    }

    /// <summary>
    /// Обрезание значения по границам
    /// </summary>
    /// <param name="val"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public double Clamp(double val, double min, double max)
    {
        val = Math.Max(val, min);
        val = Math.Min(val, max);
        return val;
    }

    /// <summary>
    /// Обрезание значения по границам 0 и 1
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    public double Clamp01(double val)
    {
        return Clamp(val, 0.0, 1.0);
    }

    /// <summary>
    /// Получение случайного единичного вектора
    /// </summary>
    /// <returns></returns>
    public Vector2 GetUniteCircle()
    {
        float rnd_angle = Range(0f, 2f * (float)Math.PI);
        Vector2 res = new Vector2((float)Math.Cos(rnd_angle), (float)Math.Sin(rnd_angle));
        res.Normalize();
        return res;
    }
}
