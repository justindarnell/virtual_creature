namespace VirtualLife.SimCore
{
    public sealed class SimCreature
    {
        private Vec2 _wanderTarget = Vec2.Zero;
        private bool _hasWanderTarget;

        public Vec2 Position { get; private set; }
        public DriveState Drives { get; } = new DriveState();
        public CreatureAction CurrentAction { get; private set; } = CreatureAction.Idle;
        public Vec2 CurrentTarget { get; private set; } = Vec2.Zero;

        public SimCreature(Vec2 startPosition)
        {
            Position = startPosition;
        }

        public void Tick(SimWorld world, SimConfig config, float deltaTime, SimRng rng)
        {
            Drives.Increase(
                config.HungerRatePerSecond * deltaTime,
                config.FatigueRatePerSecond * deltaTime
            );

            var target = DetermineTarget(world);
            if (target != null)
            {
                CurrentTarget = target.Position;
                if (Vec2.Distance(Position, target.Position) <= config.InteractDistance)
                {
                    if (target.Type == WorldObjectType.Food)
                    {
                        CurrentAction = CreatureAction.Eat;
                        Drives.ReduceHunger(config.EatReduction);
                    }
                    else
                    {
                        CurrentAction = CreatureAction.Sleep;
                        Drives.ReduceFatigue(config.SleepReduction);
                    }

                    return;
                }

                CurrentAction = CreatureAction.MoveToTarget;
                MoveTowards(CurrentTarget, world, config, deltaTime);
                return;
            }

            CurrentAction = CreatureAction.MoveRandom;
            if (!_hasWanderTarget || Vec2.Distance(Position, _wanderTarget) <= config.InteractDistance)
            {
                _wanderTarget = new Vec2(
                    rng.Range(world.WorldMin.X, world.WorldMax.X),
                    rng.Range(world.WorldMin.Y, world.WorldMax.Y)
                );
                _hasWanderTarget = true;
            }

            CurrentTarget = _wanderTarget;
            MoveTowards(CurrentTarget, world, config, deltaTime);
        }

        private WorldObject DetermineTarget(SimWorld world)
        {
            if (Drives.Hunger > 0.7f)
            {
                return world.FindNearest(WorldObjectType.Food, Position);
            }

            if (Drives.Fatigue > 0.7f)
            {
                return world.FindNearest(WorldObjectType.Bed, Position);
            }

            return null;
        }

        private void MoveTowards(Vec2 target, SimWorld world, SimConfig config, float deltaTime)
        {
            var direction = (target - Position).Normalized;
            var distance = config.MoveSpeed * deltaTime;
            var next = Position + direction * distance;
            var clamped = world.ClampToBounds(next);

            if (Vec2.Distance(clamped, Position) > 0.0001f)
            {
                Drives.Increase(0f, config.MovementFatiguePerSecond * deltaTime);
            }

            Position = clamped;
        }
    }
}
