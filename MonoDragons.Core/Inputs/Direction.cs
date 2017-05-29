
using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;

namespace MonoDragons.Core.Inputs
{
    public struct Direction
    {
        public static Direction None = new Direction(HorizontalDirection.None, VerticalDirection.None);

        public HorizontalDirection HDir { get; }
        public VerticalDirection VDir { get; }
        
        public Direction(HorizontalDirection hDir, VerticalDirection vDir)
        {
            HDir = hDir;
            VDir = vDir;
        }

        public Point AsOffset()
        {
            return new Point((int)HDir, (int)VDir);
        }

        public Rotation2 ToRotation()
        {
            if (HDir == HorizontalDirection.None && VDir == VerticalDirection.Up)
                return Rotation2.Up;
            if (HDir == HorizontalDirection.None && VDir == VerticalDirection.Down)
                return Rotation2.Down;
            if (HDir == HorizontalDirection.Left && VDir == VerticalDirection.None)
                return Rotation2.Left;
            if (HDir == HorizontalDirection.Right && VDir == VerticalDirection.None)
                return Rotation2.Right;
            if (HDir == HorizontalDirection.Left && VDir == VerticalDirection.Up)
                return Rotation2.UpLeft;
            if (HDir == HorizontalDirection.Left && VDir == VerticalDirection.Down)
                return Rotation2.DownLeft;
            if (HDir == HorizontalDirection.Right && VDir == VerticalDirection.Up)
                return Rotation2.UpRight;
            if (HDir == HorizontalDirection.Right && VDir == VerticalDirection.Down)
                return Rotation2.DownRight;
            return Rotation2.Default;
        }
    }
}
