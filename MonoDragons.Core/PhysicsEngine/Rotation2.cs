using System;
using MonoDragons.Core.Inputs;

namespace MonoDragons.Core.PhysicsEngine
{
    public struct Rotation2
    {
        public static Rotation2 None = new Rotation2(0);
        public static Rotation2 Default = new Rotation2(0);
        public static Rotation2 Up = new Rotation2(0);
        public static Rotation2 Right = new Rotation2(90);
        public static Rotation2 Down = new Rotation2(180);
        public static Rotation2 Left = new Rotation2(270);
        public static Rotation2 UpLeft = new Rotation2(315);
        public static Rotation2 UpRight= new Rotation2(45);
        public static Rotation2 DownLeft = new Rotation2(215);
        public static Rotation2 DownRight = new Rotation2(135);

        public float Value { get; }

        public Rotation2(float value)
        {
            Value = value;
        }

        public override bool Equals(object obj)
        {
            return Math.Abs(Value - ((Rotation2)obj).Value) < 0.01;
        }

        public override int GetHashCode()
        {
            return (int)Value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public static Rotation2 operator +(Rotation2 r1, Rotation2 r2)
        {
            var newValue = r1.Value + r2.Value;
            while (newValue >= 360)
                newValue -= 360;
            return new Rotation2(newValue);
        }

        public Direction ToDirection()
        {
            var hDir = HorizontalDirection.None;
            if (0 < Value && Value < 180)
                hDir = HorizontalDirection.Right;
            if (180 < Value && Value < 360)
                hDir = HorizontalDirection.Left;
            var vDir = VerticalDirection.None;
            if (90 < Value && Value < 270)
                vDir = VerticalDirection.Down;
            if (270 < Value || Value < 90)
                vDir = VerticalDirection.Up;
            return new Direction(hDir, vDir);
        }
    }
}
