using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RuntimeSet<T> : EventObject where T : UnityEngine.Object 
{
    public enum Actions
    {
        None,
        Add,
        Remove
    }

    [SerializeField] List<T> items;

    private T lastItemActionOn;
    public T LastItemActionOn
    {
        get { return lastItemActionOn; }
    }

    public Actions LastTimeAction { get => lastTimeAction; }
    public List<T> Items { get => items; }

    private Actions lastTimeAction = Actions.None;

    void OnEnable()
    {
        items = new List<T>();
        ClearCache();
    }

    void OnDisable()
    {
        Items.Clear();
        items = null;
        ClearCache();
    }

    void ClearCache()
    {
        lastItemActionOn = null;
        lastTimeAction = Actions.None;
    }

    public void Add(T item)
    {
        if (!Items.Contains(item))
        {
            items.Add(item);
            lastItemActionOn = item;
            lastTimeAction = Actions.Add;
            Invoke();
            ClearCache();
        }
            
    }

    public void Remove(T item)
    {
        if (Items.Contains(item))
        {
            items.Remove(item);
            lastItemActionOn = item;
            lastTimeAction = Actions.Remove;
            Invoke();
            ClearCache();
        }
    }

    public bool isContain(T item)
    {
        return items.Contains(item);
    }
}
