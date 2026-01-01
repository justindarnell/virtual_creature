using System;

namespace VirtualLife.SimCore
{
    public readonly struct Vec2
    {
        public readonly float X;
        public readonly float Y;

        public Vec2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public static Vec2 Zero => new Vec2(0f, 0f);

        public float Magnitude => MathF.Sqrt(X * X + Y * Y);

        public float SqrMagnitude => X * X + Y * Y;

        public Vec2 Normalized
        {
            get
            {
                var mag = Magnitude;
                if (mag <= 0.0001f)
                {
                    return Zero;
                }

                return new Vec2(X / mag, Y / mag);
            }
        }

        public static float Distance(Vec2 a, Vec2 b)
        {
            return (a - b).Magnitude;
        }

        public static Vec2 Lerp(Vec2 a, Vec2 b, float t)
        {
            return new Vec2(
                a.X + (b.X - a.X) * t,
                a.Y + (b.Y - a.Y) * t
            );
        }

        public static Vec2 operator +(Vec2 a, Vec2 b)
        {
            return new Vec2(a.X + b.X, a.Y + b.Y);
        }

        public static Vec2 operator -(Vec2 a, Vec2 b)
        {
            return new Vec2(a.X - b.X, a.Y - b.Y);
        }

        public static Vec2 operator *(Vec2 a, float scalar)
        {
            return new Vec2(a.X * scalar, a.Y * scalar);
        }

        public override string ToString()
        {
            return $"({X:0.00}, {Y:0.00})";
        }
    }
}
