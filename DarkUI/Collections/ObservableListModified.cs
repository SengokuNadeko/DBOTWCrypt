using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace DarkUI.Collections
{
    public class ObservableListModified<T> : EventArgs
    {
        public IEnumerable<T> Items { get; }

        public ObservableListModified(IEnumerable<T> items)
        {
            Items = items;
        }
    }

    public class ObservableListChanged<T> : EventArgs
    {
        public IEnumerable<T> NewItems { get; }

        public IEnumerable<T> OldItems { get; }

        public NotifyCollectionChangedAction Action { get; }

        public ObservableListChanged(IEnumerable<T> items, NotifyCollectionChangedAction action)
        {
            Action = action;

            switch (action)
            {
                case NotifyCollectionChangedAction.Add:
                    NewItems = items;
                    break;
                case NotifyCollectionChangedAction.Remove:
                    OldItems = items;
                    break;
            }
        }
    }
}
