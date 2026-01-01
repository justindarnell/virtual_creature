namespace VirtualLife.SimCore
{
    public sealed class WorldObject
    {
        public int Id { get; }
        public WorldObjectType Type { get; }
        public Vec2 Position { get; set; }

        public WorldObject(int id, WorldObjectType type, Vec2 position)
        {
            Id = id;
            Type = type;
            Position = position;
        }
    }
}
