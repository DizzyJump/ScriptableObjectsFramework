using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWeightPeriodGenerator<T>
{
    struct RandomWeight
    {
        public float min;
        public float max;
        public T result;

        public bool check(float val)
        {
            return (val >= min && val < max);
        }
    }

    float CurrentMax = 0f;
    List<RandomWeight> weights_list = new List<RandomWeight>();
    RandomTools rnd = new RandomTools();

    public void Add(float weight, T obj)
    {
        RandomWeight new_weight = new RandomWeight();
        new_weight.result = obj;
        new_weight.min = CurrentMax;
        CurrentMax = new_weight.max = CurrentMax + weight;
        weights_list.Add(new_weight);
    }

    public T GetRandomObject()
    {
        float rnd_val = rnd.Range(0f, CurrentMax - 0.0000001f);
        foreach(var w in weights_list)
            if(w.check(rnd_val))
                return w.result;
        return default(T);
    }

    public int Count()
    {
        return weights_list.Count;
    }
}
