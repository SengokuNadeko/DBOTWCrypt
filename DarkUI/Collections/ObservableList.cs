using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace DarkUI.Collections
{
    public class ObservableList<T> : List<T>, IDisposable
    {
        #region Field Region

        private bool _disposed;

        #endregion

        #region Event Region

        public event EventHandler<ObservableListModified<T>> ItemsAdded;
        public event EventHandler<ObservableListModified<T>> ItemsRemoved;
        public event EventHandler<ObservableListChanged<T>> ItemsChanged;

        #endregion

        #region Destructor Region

        ~ObservableList()
        {
            Dispose(false);
        }

        #endregion

        #region Dispose Region

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            
            ItemsAdded = null;
            ItemsRemoved = null;

            _disposed = true;
        }

        #endregion

        #region Method Region

        public new void Add(T item)
        {
            base.Add(item);

            ItemsAdded?.Invoke(this, new ObservableListModified<T>(new List<T> { item }));
            ItemsChanged?.Invoke(this, new ObservableListChanged<T>(new List<T> { item }, NotifyCollectionChangedAction.Add));
        }

        public new void AddRange(IEnumerable<T> collection)
        {
            var list = collection.ToList();

            base.AddRange(list);

            ItemsAdded?.Invoke(this, new ObservableListModified<T>(list));
            ItemsChanged?.Invoke(this, new ObservableListChanged<T>(list, NotifyCollectionChangedAction.Add));
        }

        public new void Remove(T item)
        {
            base.Remove(item);

            ItemsRemoved?.Invoke(this, new ObservableListModified<T>(new List<T> { item }));
            ItemsChanged?.Invoke(this, new ObservableListChanged<T>(new List<T> { item }, NotifyCollectionChangedAction.Remove));
        }

        #endregion
    }
}
