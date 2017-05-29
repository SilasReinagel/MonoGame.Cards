using System.Collections.Generic;
using System.Linq;

namespace MonoDragons.Core.Common
{
    public abstract class Subject<T> : ISubject<T>
    {
        protected readonly List<ISubscription<T>> _observers = new List<ISubscription<T>>();

        public virtual void Subscribe(ISubscription<T> subscription)
        {
            _observers.Add(subscription);
        }

        public virtual void UnsubscribeAll()
        {
            _observers.Clear();
        }

        public virtual void Unsubscribe(ISubscription<T> subscription)
        {
            _observers.Remove(subscription);
        }

        protected void NotifySubscribers(T obj)
        {
            var observers = _observers.Select(x => x).ToList();
            observers.ForEach(x => x.Update(obj));
        }
    }

    public abstract class Subject<T1, T2> : ISubject<T1, T2>
    {
        protected readonly List<ISubscription<T1>> _observers1 = new List<ISubscription<T1>>();
        protected readonly List<ISubscription<T2>> _observers2 = new List<ISubscription<T2>>();

        public virtual void Subscribe(ISubscription<T1> subscription)
        {
            _observers1.Add(subscription);
        }

        public virtual void Subscribe(ISubscription<T2> subscription)
        {
            _observers2.Add(subscription);
        }

        public virtual void UnsubscribeAll()
        {
            _observers1.Clear();
            _observers2.Clear();
        }

        public virtual void Unsubscribe(ISubscription<T1> subscription)
        {
            _observers1.Remove(subscription);
        }

        public virtual void Unsubscribe(ISubscription<T2> subscription)
        {
            _observers2.Remove(subscription);
        }

        protected void NotifySubscribers(T1 obj)
        {
            var observers = _observers1.Select(x => x).ToList();
            observers.ForEach(x => x.Update(obj));
        }

        protected void NotifySubscribers(T2 obj)
        {
            var observers = _observers2.Select(x => x).ToList();
            observers.ForEach(x => x.Update(obj));
        }
    }
}
