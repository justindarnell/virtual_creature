using System.Collections.Generic;

namespace VirtualLife.SimCore
{
    public sealed class SimWorld
    {
        private readonly List<WorldObject> _objects = new List<WorldObject>();

        public Vec2 WorldMin { get; private set; }
        public Vec2 WorldMax { get; private set; }

        public IReadOnlyList<WorldObject> Objects => _objects;

        public void SetBounds(Vec2 min, Vec2 max)
        {
            WorldMin = min;
            WorldMax = max;
        }

        public void SetObjects(IEnumerable<WorldObject> objects)
        {
            _objects.Clear();
            _objects.AddRange(objects);
        }

        public WorldObject FindNearest(WorldObjectType type, Vec2 position)
        {
            WorldObject nearest = null;
            var bestDist = float.MaxValue;

            foreach (var obj in _objects)
            {
                if (obj.Type != type)
                {
                    continue;
                }

                var dist = (obj.Position - position).SqrMagnitude;
                if (dist < bestDist)
                {
                    bestDist = dist;
                    nearest = obj;
                }
            }

            return nearest;
        }

        public Vec2 ClampToBounds(Vec2 position)
        {
            var x = position.X;
            var y = position.Y;

            if (x < WorldMin.X)
            {
                x = WorldMin.X;
            }
            else if (x > WorldMax.X)
            {
                x = WorldMax.X;
            }

            if (y < WorldMin.Y)
            {
                y = WorldMin.Y;
            }
            else if (y > WorldMax.Y)
            {
                y = WorldMax.Y;
            }

            return new Vec2(x, y);
        }
    }
}
