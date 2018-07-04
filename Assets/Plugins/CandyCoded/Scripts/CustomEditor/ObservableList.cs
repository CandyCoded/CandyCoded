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

    public void CopyTo(T[] array, int arrayIndex)
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

}
