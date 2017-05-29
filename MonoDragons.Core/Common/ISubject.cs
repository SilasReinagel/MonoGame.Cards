namespace MonoDragons.Core.Common
{
    public interface ISubject<T>
    {
        void Subscribe(ISubscription<T> subscription);
        void Unsubscribe(ISubscription<T> subscription);
        void UnsubscribeAll();
    }

    public interface ISubject<T1, T2>
    {
        void Subscribe(ISubscription<T1> subscription);
        void Unsubscribe(ISubscription<T1> subscription);
        void Subscribe(ISubscription<T2> subscription);
        void Unsubscribe(ISubscription<T2> subscription);
        void UnsubscribeAll();
    }
}
