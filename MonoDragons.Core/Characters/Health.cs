
namespace MonoDragons.Core.Characters
{
    public sealed class Health
    {
        public int Max { get; set; }
        public int HP { get; set; }

        public Health(int max)
        {
            Max = max;
            HP = max;
        }
    }
}
