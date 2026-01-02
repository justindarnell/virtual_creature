namespace VirtualLife.SimCore
{
    public sealed class SimRng
    {
        private uint _state;

        public SimRng(uint seed)
        {
            _state = seed == 0 ? 0xCAFEBABE : seed;
        }

        public uint NextUInt()
        {
            var x = _state;
            x ^= x << 13;
            x ^= x >> 17;
            x ^= x << 5;
            _state = x;
            return x;
        }

        public float NextFloat()
        {
            return (NextUInt() & 0xFFFFFF) / (float)0x1000000;
        }

        public float Range(float minInclusive, float maxInclusive)
        {
            return minInclusive + (maxInclusive - minInclusive) * NextFloat();
        }
    }
}
