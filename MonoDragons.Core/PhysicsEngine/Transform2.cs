using Microsoft.Xna.Framework;

namespace MonoDragons.Core.PhysicsEngine
{
    public class Transform2
    {
        public static Transform2 Zero = new Transform2(Vector2.Zero, Size2.Zero);

        public Vector2 Location { get; set; }
        public Rotation2 Rotation { get; set;}
        public float Scale { get; set; }
        public Size2 Size { get; set; }
        public int ZIndex { get; set; } = 0;

        public Transform2(Rectangle rectangle)
            : this(new Vector2(rectangle.Location.X, rectangle.Location.Y), new Size2(rectangle.Size.X, rectangle.Size.Y)) { }

        public Transform2(float scale)
            : this(Vector2.Zero, Rotation2.Default, Size2.Zero, scale) { }

        public Transform2(Rotation2 rotation)
            : this(Vector2.Zero, rotation, Size2.Zero, 1) { }

        public Transform2(Vector2 location)
            : this(location, Rotation2.Default, Size2.Zero, 1) { }

        public Transform2(Vector2 location, float scale)
            : this(location, Rotation2.Default, Size2.Zero, scale) { }

        public Transform2(Size2 size)
            : this(Vector2.Zero, Rotation2.Default, size, 1) { }

        public Transform2(Vector2 location, Rotation2 rotation, float scale)
            : this(location, rotation, Size2.Zero, scale) { }

        public Transform2(Vector2 location, Size2 size)
            : this(location, Rotation2.Default, size, 1) { }

        public Transform2(Vector2 location, Rotation2 rotation, Size2 size, float scale)
            : this(location, rotation, size, scale, 0) { }

        public Transform2(Vector2 location, Rotation2 rotation, Size2 size, float scale, int zIndex)
        {
            Location = location;
            Rotation = rotation;
            Size = size;
            Scale = scale;
            ZIndex = zIndex;
        }

        public bool Intersects(Transform2 other)
        {
            return ToRectangle().Intersects(other.ToRectangle());
        }

        public Transform2 WithSize(Size2 size)
        {
            return new Transform2(Location, Rotation, size, Scale, ZIndex);
        }

        public Rectangle ToRectangle()
        {
            return new Rectangle((Location * Scale).ToPoint(), (Size * Scale).ToPoint());
        }

        public Transform2 WithPadding(int x, int y)
        {
            return WithPadding(new Size2(x, y));
        }

        public Transform2 WithPadding(Size2 paddingAmount)
        {
            return new Transform2(Location + paddingAmount.ToVector(), Rotation, Size - (paddingAmount * 2), Scale, ZIndex);
        }

        public override string ToString()
        {
            return $"{Location} {Size} {Rotation} {Scale} {ZIndex}";
        }

        public static Transform2 operator +(Transform2 t1, Transform2 t2)
        {
            return new Transform2(t1.Location + t2.Location, t1.Rotation + t2.Rotation, t1.Size + t2.Size, t1.Scale * t2.Scale, t1.ZIndex);
        }

        public static Transform2 operator +(Transform2 t1, Vector2 by)
        {
            return new Transform2(t1.Location + by, t1.Rotation, t1.Size, t1.Scale, t1.ZIndex);
        }

        public static Transform2 operator +(Transform2 t1, float scale)
        {
            return new Transform2(t1.Location, t1.Rotation, t1.Size, t1.Scale * scale);
        }

        public Transform2 ToScale(float scale)
        {
            return this + new Transform2(Vector2.Zero, Rotation2.Default, Size2.Zero, Scale / scale, ZIndex);
        }
    }
}
