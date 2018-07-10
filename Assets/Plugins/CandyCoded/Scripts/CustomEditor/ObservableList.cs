using System.Collections;
using System.Collections.Generic;

public class ObservableList<T> : IList<T>
{

    public delegate void EventHandlerWithItem(T item);
    public delegate void EventHandlerWithItems(T[] items);
    public delegate void EventHandler();

    public event EventHandlerWithItem AddEvent;
    public event EventHandler ClearEvent;
    public event EventHandler RemoveEvent;

    private IList<T> _items;

    public int Count
    {
        get { return _items.Count; }
    }

    public bool IsReadOnly
    {
        get { return _items.IsReadOnly; }
    }

    public ObservableList()
    {

        _items = new List<T>();

    }

    public ObservableList(IList<T> items)
    {

        _items = new List<T>(items);

    }

    public ObservableList(IEnumerable<T> items)
    {

        _items = new List<T>(items);

    }

    public T this[int index]
    {
        get { return _items[index]; }
        set { _items[index] = value; }
    }

    public IEnumerator<T> GetEnumerator()
    {

        return _items.GetEnumerator();

    }

    IEnumerator IEnumerable.GetEnumerator()
    {

        return GetEnumerator();

    }

    public void Add(T item)
    {

        if (AddEvent != null)
        {
            AddEvent(item);
        }

        _items.Add(item);

    }

    public void Clear()
    {

        if (ClearEvent != null)
        {
            ClearEvent();
        }

        _items.Clear();

    }

    public bool Contains(T item)
    {

        return _items.Contains(item);

    }

    public void CopyTo(T[] array, int arrayIndex = 0)
    {

        _items.CopyTo(array, arrayIndex);

    }

    public int IndexOf(T item)
    {

        return _items.IndexOf(item);

    }

    public void Insert(int index, T item)
    {

        if (AddEvent != null)
        {
            AddEvent(item);
        }

        _items.Insert(index, item);

    }

    public bool Remove(T item)
    {

        if (RemoveEvent != null)
        {
            RemoveEvent();
        }

        return _items.Remove(item);

    }

    public void RemoveAt(int index)
    {

        if (RemoveEvent != null)
        {
            RemoveEvent();
        }

        _items.RemoveAt(index);

    }

    public ObservableList<T> GetRange(int index, int count)
    {

        ObservableList<T> items = new ObservableList<T>();

        for (int i = index; i < index + count; i += 1)
        {

            items.Add(_items[i]);

        }

        return items;

    }

    public void AddRange(List<T> items)
    {

        for (int i = 0; i < items.Count; i += 1)
        {

            _items.Add(items[i]);

        }

    }

    public void AddRange(ObservableList<T> items)
    {

        for (int i = 0; i < items.Count; i += 1)
        {

            _items.Add(items[i]);

        }

    }

    public void RemoveRange(int index, int count)
    {

        for (int i = index; i < index + count; i += 1)
        {

            _items.RemoveAt(i);

        }

    }

    /// <summary>
    /// Creates a new copy of an Observablelist and shuffles the values.
    /// </summary>
    /// <returns>ObservableList<typeparamref name="T"/>></returns>
    public ObservableList<T> Shuffle()
    {

        ObservableList<T> shuffledList = new ObservableList<T>(_items);

        int count = shuffledList.Count;

        for (int i = 0; i < count; i += 1)
        {

            int randomIndex = UnityEngine.Random.Range(i, count);

            T tempValue = shuffledList[i];

            shuffledList[i] = shuffledList[randomIndex];

            shuffledList[randomIndex] = tempValue;

        }

        return shuffledList;

    }

    /// <summary>
    /// Returns a shallow copy of a portion of an Observablelist.
    /// </summary>
    /// <param name="index">Index of list to start at.</param>
    /// <param name="count">Number of items to return.</param>
    /// <returns>ObservableList<typeparamref name="T"/>></returns>
    public ObservableList<T> Slice(int index, int count)
    {

        ObservableList<T> partialList = GetRange(index, count);

        return partialList;

    }

    /// <summary>
    /// Returns a shallow copy of a portion of an Observablelist.
    /// </summary>
    /// <param name="count">Number of items to return.</param>
    /// <returns>ObservableList<typeparamref name="T"/>></returns>
    public ObservableList<T> Slice(int count = 1)
    {

        return Slice(0, count);

    }

    /// <summary>
    /// Removes and returns a shallow copy of a portion of an Observablelist.
    /// </summary>
    /// <param name="index">Index of list to start at.</param>
    /// <param name="count">Number of items to return and remove.</param>
    /// <returns>ObservableList<typeparamref name="T"/>></returns>
    public ObservableList<T> Splice(int index, int count)
    {

        ObservableList<T> partialList = GetRange(index, count);

        RemoveRange(index, count);

        return partialList;

    }

    /// <summary>
    /// Removes and returns a shallow copy of a portion of an Observablelist.
    /// </summary>
    /// <param name="count">Number of items to return and remove.</param>
    /// <returns>ObservableList<typeparamref name="T"/>></returns>
    public ObservableList<T> Splice(int count = 1)
    {

        return Splice(0, count);

    }

    public static explicit operator List<T>(ObservableList<T> observableList)
    {

        List<T> newList = new List<T>(observableList);

        return newList;

    }

}
