using System.Collections.Generic;
using UnityEngine;

public abstract class ListReference<T> : ScriptableObject
{

    public List<T> Items = new List<T>();

    public int Count
    {
        get { return Items.Count; }
    }

    public void Add(T item)
    {

        if (!Items.Contains(item))
        {

            Items.Add(item);

        }

    }

    public bool Remove(T item)
    {

        return Items.Remove(item);

    }

    public void Clear()
    {

        Items.Clear();

    }

}
