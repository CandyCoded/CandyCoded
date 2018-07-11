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

    /// <summary>
    /// Adds an object to the end of the ObservableList.
    /// </summary>
    /// <param name="item">The object to be added to the end of the ObservableList.</param>
    /// <returns>void</returns>
    public void Add(T item)
    {

        if (AddEvent != null)
        {
            AddEvent(item);
        }

        _items.Add(item);

    }

    /// <summary>
    /// Removes all objects from the ObservableList.
    /// </summary>
    /// <returns>void</returns>
    public void Clear()
    {

        if (ClearEvent != null)
        {
            ClearEvent();
        }

        _items.Clear();

    }

    /// <summary>
    /// Determines whether an element is in the ObservableList.
    /// </summary>
    /// <param name="item">The object to locate in the ObservableList.</param>
    /// <returns>bool</returns>
    public bool Contains(T item)
    {

        return _items.Contains(item);

    }

    /// <summary>
    /// Copies all items in the ObservableList to the array starting at the <paramref name="arrayIndex"/>.
    /// </summary>
    /// <param name="array">The one-dimensional Array that is the destination of the elements copied from the ObservableList.</param>
    /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
    /// <returns>void</returns>
    public void CopyTo(T[] array, int arrayIndex)
    {

        _items.CopyTo(array, arrayIndex);

    }

    /// <summary>
    /// Searches for the specified object and returns the zero-based index of the first occurrence within the entire ObservableList.
    /// </summary>
    /// <param name="item">The object to locate in the ObservableList.</param>
    /// <returns>int</returns>
    public int IndexOf(T item)
    {

        return _items.IndexOf(item);

    }

    /// <summary>
    /// Inserts an element into the ObservableList at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index at which item should be inserted.</param>
    /// <param name="item">The object to insert.</param>
    /// <returns>void</returns>
    public void Insert(int index, T item)
    {

        if (AddEvent != null)
        {
            AddEvent(item);
        }

        _items.Insert(index, item);

    }

    /// <summary>
    /// Removes the first occurrence of a specific object from the ObservableList.
    /// </summary>
    /// <param name="item">The object to remove from the ObservableList.</param>
    /// <returns>bool</returns>
    public bool Remove(T item)
    {

        if (RemoveEvent != null)
        {
            RemoveEvent();
        }

        return _items.Remove(item);

    }

    /// <summary>
    /// Removes the element at the specified index of the ObservableList.
    /// </summary>
    /// <param name="index">The zero-based index of the element to remove.</param>
    /// <returns>void</returns>
    public void RemoveAt(int index)
    {

        if (RemoveEvent != null)
        {
            RemoveEvent();
        }

        _items.RemoveAt(index);

    }

    /// <summary>
    /// Creates a shallow copy of a range of elements in the source ObservableList.
    /// </summary>
    /// <param name="index">The zero-based index at which the range starts.</param>
    /// <param name="count">The number of elements in the range.</param>
    /// <returns>ObservableList<typeparamref name="T"/>></returns>
    public ObservableList<T> GetRange(int index, int count)
    {

        ObservableList<T> items = new ObservableList<T>();

        for (int i = index; i < index + count; i += 1)
        {

            items.Add(_items[i]);

        }

        return items;

    }

    /// <summary>
    /// Adds the elements of the specified collection to the end of the ObservableList.
    /// </summary>
    /// <param name="items">The collection whose elements should be added to the end of the ObservableList.</param>
    /// <returns>void</returns>
    public void AddRange(List<T> items)
    {

        for (int i = 0; i < items.Count; i += 1)
        {

            Add(items[i]);

        }

    }

    /// <summary>
    /// Adds the elements of the specified collection to the end of the ObservableList.
    /// </summary>
    /// <param name="items">The collection whose elements should be added to the end of the ObservableList.</param>
    /// <returns>void</returns>
    public void AddRange(ObservableList<T> items)
    {

        for (int i = 0; i < items.Count; i += 1)
        {

            Add(items[i]);

        }

    }

    /// <summary>
    /// Removes a range of elements from the ObservableList.
    /// </summary>
    /// <param name="index">The zero-based starting index of the range of elements to remove.</param>
    /// <param name="count">The number of elements to remove.</param>
    /// <returns>void</returns>
    public void RemoveRange(int index, int count)
    {

        for (int i = index; i < index + count; i += 1)
        {

            RemoveAt(i);

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
