namespace VirtualLife.SimCore
{
    public sealed class DriveState
    {
        public float Hunger { get; private set; }
        public float Fatigue { get; private set; }

        public void Increase(float hungerDelta, float fatigueDelta)
        {
            Hunger = Clamp01(Hunger + hungerDelta);
            Fatigue = Clamp01(Fatigue + fatigueDelta);
        }

        public void ReduceHunger(float amount)
        {
            Hunger = Clamp01(Hunger - amount);
        }

        public void ReduceFatigue(float amount)
        {
            Fatigue = Clamp01(Fatigue - amount);
        }

        private static float Clamp01(float value)
        {
            if (value < 0f)
            {
                return 0f;
            }

            return value > 1f ? 1f : value;
        }
    }
}
