namespace MonoDragons.Core.PhysicsEngine
{
    public sealed class Sprite
    {
        private string _suffix;
        public string Prefix { get; set; } = "";

        public string Name
        {
            get { return Prefix + _suffix; }
            set { _suffix = value; }
        }

        public Sprite(string name)
        {
            _suffix = name;
        }

        public Sprite(string prefix, string suffix)
        {
            _suffix = suffix;
            Prefix = prefix;
        }
    }
}
