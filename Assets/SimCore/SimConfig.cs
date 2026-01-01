namespace VirtualLife.SimCore
{
    public sealed class SimConfig
    {
        public float HungerRatePerSecond { get; set; } = 0.015f;
        public float FatigueRatePerSecond { get; set; } = 0.01f;
        public float UrgentDriveThreshold { get; set; } = 0.7f;
        public float MovementFatiguePerSecond { get; set; } = 0.02f;
        public float EatReduction { get; set; } = 0.4f;
        public float SleepReduction { get; set; } = 0.5f;
        public float MoveSpeed { get; set; } = 1.5f;
        public float InteractDistance { get; set; } = 0.4f;
        public Vec2 WorldMin { get; set; } = new Vec2(-5f, -3f);
        public Vec2 WorldMax { get; set; } = new Vec2(5f, 3f);
    }
}
