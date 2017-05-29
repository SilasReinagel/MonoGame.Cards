
namespace MonoDragons.Core.Entities
{
    public interface IEntitySystemRegistration
    {
        void Register(ISystem system);
        void Register(IRenderer renderer);
    }
}
