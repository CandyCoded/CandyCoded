using System.Collections.Generic;

public class ObservableList<T> : List<T>
{

    public delegate void EventHandlerWithItem(T item);
    public delegate void EventHandler();
    public event EventHandlerWithItem AddEvent;
    public event EventHandler ClearEvent;
    public event EventHandler RemoveEvent;

    public new void Add(T item)
    {

        if (AddEvent != null)
        {
            AddEvent(item);
        }

        base.Add(item);

    }

    public new void Clear()
    {

        if (ClearEvent != null)
        {
            ClearEvent();
        }

        base.Clear();

    }

    public new bool Remove(T item)
    {

        if (RemoveEvent != null)
        {
            RemoveEvent();
        }

        return base.Remove(item);

    }
}
