namespace MonoDragons.Core.Common
{
    public interface ISubscription<in T>
    {
        void Update(T change);
    }
}
