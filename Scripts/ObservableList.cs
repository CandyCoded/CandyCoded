// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CandyCoded
{

    /// <summary>
    ///     ObservableList
    /// </summary>
    [Serializable]
    public class ObservableList<T> : IList<T>
    {

        public delegate void EventHandler();

        public delegate void EventHandlerWithItem(T item);

        public delegate void EventHandlerWithItems(T[] items);

        private readonly IList<T> _items;

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

        /// <summary>
        ///     Gets the number of items contained in the ObservableList.
        /// </summary>
        /// <returns>int</returns>
        public int Count => _items.Count;

        /// <summary>
        ///     Gets a value indicating whether the ObservableList is read-only.
        /// </summary>
        /// <returns>bool</returns>
        public bool IsReadOnly => _items.IsReadOnly;

        public T this[int index]
        {
            get => _items[index];
            set => _items[index] = value;
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
        ///     Adds an item to the end of the ObservableList.
        /// </summary>
        /// <param name="item">The item to be added to the end of the ObservableList.</param>
        /// <returns>void</returns>
        public void Add(T item)
        {

            _items.Add(item);

            AddEvent?.Invoke(item);

        }

        /// <summary>
        ///     Removes all items from the ObservableList.
        /// </summary>
        /// <returns>void</returns>
        public void Clear()
        {

            _items.Clear();

            ClearEvent?.Invoke();

        }

        /// <summary>
        ///     Determines whether an item is in the ObservableList.
        /// </summary>
        /// <param name="item">The item to locate in the ObservableList.</param>
        /// <returns>bool</returns>
        public bool Contains(T item)
        {

            return _items.Contains(item);

        }

        /// <summary>
        ///     Copies all items in the ObservableList to the array starting at the <paramref name="arrayIndex" />.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the items copied from the ObservableList.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        /// <returns>void</returns>
        public void CopyTo(T[] array, int arrayIndex)
        {

            _items.CopyTo(array, arrayIndex);

        }

        /// <summary>
        ///     Searches for the specified item and returns the zero-based index of the first occurrence within the entire
        ///     ObservableList.
        /// </summary>
        /// <param name="item">The item to locate in the ObservableList.</param>
        /// <returns>int</returns>
        public int IndexOf(T item)
        {

            return _items.IndexOf(item);

        }

        /// <summary>
        ///     Inserts an item into the ObservableList at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="item">The item to insert.</param>
        /// <returns>void</returns>
        public void Insert(int index, T item)
        {

            _items.Insert(index, item);

            AddEvent?.Invoke(item);

        }

        /// <summary>
        ///     Removes the first occurrence of a specific item from the ObservableList.
        /// </summary>
        /// <param name="item">The item to remove from the ObservableList.</param>
        /// <returns>bool</returns>
        public bool Remove(T item)
        {

            var result = _items.Remove(item);

            RemoveEvent?.Invoke(item);

            return result;

        }

        /// <summary>
        ///     Removes the item at the specified index of the ObservableList.
        /// </summary>
        /// <param name="index">The zero-based index of the item to remove.</param>
        /// <returns>void</returns>
        public void RemoveAt(int index)
        {

            var item = _items[index];

            _items.RemoveAt(index);

            RemoveEvent?.Invoke(item);

        }

        public event EventHandlerWithItem AddEvent;

        public event EventHandler ClearEvent;

        public event EventHandlerWithItem RemoveEvent;

        /// <summary>
        ///     Adds the items of an IEnumerable collection to the end of the ObservableList.
        /// </summary>
        /// <param name="items">The collection whose items should be added to the end of the ObservableList.</param>
        /// <returns>void</returns>
        public void AddRange(IEnumerable<T> items)
        {

            foreach (var item in items)
            {

                Add(item);

            }

        }

        /// <summary>
        ///     Creates a shallow copy of a range of items in the source ObservableList.
        /// </summary>
        /// <param name="index">The zero-based index at which the range starts.</param>
        /// <param name="count">The number of items in the range.</param>
        /// <returns>ObservableList<typeparamref name="T" /></returns>
        public ObservableList<T> GetRange(int index, int count)
        {

            var items = new ObservableList<T>();

            for (var i = index; i < index + count; i += 1)
            {

                items.Add(_items[i]);

            }

            return items;

        }

        /// <summary>
        ///     Inserts the items of an IEnumerable collection into the ObservableList at the specified index.
        /// </summary>
        /// <returns>void</returns>
        public void InsertRange(int index, IEnumerable<T> items)
        {

            var i = 0;

            foreach (var item in items)
            {

                Insert(i + index, item);

                i += 1;

            }

        }

        /// <summary>
        ///     Removes the last item from an ObservableList and returns that item.
        /// </summary>
        /// <returns>
        ///     <typeparamref name="T" />
        /// </returns>
        public T Pop()
        {

            var item = _items[_items.Count - 1];

            RemoveAt(_items.Count - 1);

            return item;

        }

        /// <summary>
        ///     Returns a random item from an ObservableList.
        /// </summary>
        /// <returns>
        ///     <typeparamref name="T" />
        /// </returns>
        public T Random()
        {

            return _items[UnityEngine.Random.Range(0, _items.Count)];

        }

        /// <summary>
        ///     Removes a range of items from the ObservableList.
        /// </summary>
        /// <param name="index">The zero-based starting index of the range of items to remove.</param>
        /// <param name="count">The number of items to remove.</param>
        /// <returns>void</returns>
        public void RemoveRange(int index, int count)
        {

            for (var i = index + count - 1; i > index - 1; i -= 1)
            {

                RemoveAt(i);

            }

        }

        /// <summary>
        ///     Removes the first item from an ObservableList and returns that item.
        /// </summary>
        /// <returns>
        ///     <typeparamref name="T" />
        /// </returns>
        public T Shift()
        {

            var item = _items[0];

            RemoveAt(0);

            return item;

        }

        /// <summary>
        ///     Creates a new copy of an ObservableList and shuffles the items.
        /// </summary>
        /// <param name="seed">A number used for randomly shuffling the items of the list.</param>
        /// <returns>ObservableList<typeparamref name="T" /></returns>
        public ObservableList<T> Shuffle(int seed)
        {

            var random = new Random(seed);

            var shuffledList = new ObservableList<T>(_items.OrderBy(_ => random.Next()));

            return shuffledList;

        }

        /// <summary>
        ///     Creates a new copy of an ObservableList and shuffles the items.
        /// </summary>
        /// <returns>ObservableList<typeparamref name="T" /></returns>
        public ObservableList<T> Shuffle()
        {

            var random = new Random();

            var shuffledList = new ObservableList<T>(_items.OrderBy(_ => random.Next()));

            return shuffledList;

        }

        /// <summary>
        ///     Returns a shallow copy of a portion of an ObservableList.
        /// </summary>
        /// <param name="index">Index of list to start at.</param>
        /// <param name="count">Number of items to return.</param>
        /// <returns>ObservableList<typeparamref name="T" /></returns>
        public ObservableList<T> Slice(int index, int count)
        {

            var partialList = GetRange(index, count);

            return partialList;

        }

        /// <summary>
        ///     Returns a shallow copy of a portion of an ObservableList.
        /// </summary>
        /// <param name="count">Number of items to return.</param>
        /// <returns>ObservableList<typeparamref name="T" /></returns>
        public ObservableList<T> Slice(int count)
        {

            return Slice(0, count);

        }

        /// <summary>
        ///     Returns a shallow copy of a portion of an ObservableList.
        /// </summary>
        /// <returns>ObservableList<typeparamref name="T" /></returns>
        public ObservableList<T> Slice()
        {

            return Slice(0, 1);

        }

        /// <summary>
        ///     Removes and returns a shallow copy of a portion of an ObservableList.
        /// </summary>
        /// <param name="index">Index of list to start at.</param>
        /// <param name="count">Number of items to return and remove.</param>
        /// <returns>ObservableList<typeparamref name="T" /></returns>
        public ObservableList<T> Splice(int index, int count)
        {

            var partialList = GetRange(index, count);

            RemoveRange(index, count);

            return partialList;

        }

        /// <summary>
        ///     Removes and returns a shallow copy of a portion of an ObservableList.
        /// </summary>
        /// <param name="count">Number of items to return and remove.</param>
        /// <returns>ObservableList<typeparamref name="T" /></returns>
        public ObservableList<T> Splice(int count)
        {

            return Splice(0, count);

        }

        /// <summary>
        ///     Removes and returns a shallow copy of a portion of an ObservableList.
        /// </summary>
        /// <returns>ObservableList<typeparamref name="T" /></returns>
        public ObservableList<T> Splice()
        {

            return Splice(0, 1);

        }

        /// <summary>
        ///     Creates a List with the values from an ObservableList.
        /// </summary>
        /// <returns>List<typeparamref name="T" /></returns>
        public List<T> ToList()
        {

            var newList = new List<T>(_items);

            return newList;

        }

        /// <summary>
        ///     Adds a range of items to the beginning of an ObservableList.
        /// </summary>
        /// <returns>void</returns>
        public void Unshift(IEnumerable<T> items)
        {

            InsertRange(0, items);

        }

        /// <summary>
        ///     Adds a range of items to the beginning of an ObservableList.
        /// </summary>
        /// <returns>void</returns>
        public void Unshift(ObservableList<T> items)
        {

            InsertRange(0, items);

        }

        /// <summary>
        ///     Adds an item to the beginning of an ObservableList.
        /// </summary>
        /// <returns>void</returns>
        public void Unshift(T item)
        {

            Insert(0, item);

        }

        public static explicit operator List<T>(ObservableList<T> observableList)
        {

            var newList = new List<T>(observableList);

            return newList;

        }

    }

}
