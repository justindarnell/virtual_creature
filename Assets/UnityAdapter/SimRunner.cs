using System.Collections.Generic;
using UnityEngine;
using VirtualLife.SimCore;

namespace VirtualLife.UnityAdapter
{
    public sealed class SimRunner : MonoBehaviour
    {
        [Header("Simulation Loop")]
        [SerializeField] private float tickRate = 10f;
        [SerializeField] private int randomSeed = 12345;

        [Header("World Bounds")]
        [SerializeField] private Vector2 worldMin = new Vector2(-5f, -3f);
        [SerializeField] private Vector2 worldMax = new Vector2(5f, 3f);

        [Header("Creature")]
        [SerializeField] private CreatureView creatureView;

        [Header("Drive Rates")]
        [SerializeField] private float hungerRatePerSecond = 0.015f;
        [SerializeField] private float fatigueRatePerSecond = 0.01f;
        [SerializeField] private float urgentDriveThreshold = 0.7f;
        [SerializeField] private float movementFatiguePerSecond = 0.02f;

        [Header("Action Effects")]
        [SerializeField] private float eatReduction = 0.4f;
        [SerializeField] private float sleepReduction = 0.5f;

        [Header("Movement")]
        [SerializeField] private float moveSpeed = 1.5f;
        [SerializeField] private float interactDistance = 0.4f;

        private readonly List<WorldObject> _worldObjects = new List<WorldObject>();
        private readonly List<FoodView> _foods = new List<FoodView>();
        private readonly List<BedView> _beds = new List<BedView>();
        private SimWorld _world;
        private SimCreature _creature;
        private SimConfig _config;
        private SimRng _rng;
        private float _accumulator;

        public SimCreature Creature => _creature;

        private void Awake()
        {
            if (creatureView == null)
            {
                creatureView = FindObjectOfType<CreatureView>();
            }

            _config = new SimConfig
            {
                HungerRatePerSecond = hungerRatePerSecond,
                FatigueRatePerSecond = fatigueRatePerSecond,
                UrgentDriveThreshold = urgentDriveThreshold,
                MovementFatiguePerSecond = movementFatiguePerSecond,
                EatReduction = eatReduction,
                SleepReduction = sleepReduction,
                MoveSpeed = moveSpeed,
                InteractDistance = interactDistance,
                WorldMin = new Vec2(worldMin.x, worldMin.y),
                WorldMax = new Vec2(worldMax.x, worldMax.y)
            };

            _world = new SimWorld();
            _world.SetBounds(_config.WorldMin, _config.WorldMax);

            var start = creatureView != null
                ? new Vec2(creatureView.transform.position.x, creatureView.transform.position.y)
                : Vec2.Zero;
            _creature = new SimCreature(start);

            _rng = new SimRng((uint)randomSeed);
            RefreshWorldObjects();
        }

        private void FixedUpdate()
        {
            if (tickRate <= 0f || _creature == null)
            {
                return;
            }

            var tickDelta = 1f / tickRate;
            _accumulator += Time.fixedDeltaTime;

            while (_accumulator >= tickDelta)
            {
                RefreshWorldObjects();
                _creature.Tick(_world, _config, tickDelta, _rng);
                _accumulator -= tickDelta;
            }

            if (creatureView != null)
            {
                creatureView.ApplyPosition(_creature.Position);
            }
        }

        private void RefreshWorldObjects()
        {
            _worldObjects.Clear();
            var id = 0;
            foreach (var food in _foods)
            {
                if (food == null)
                {
                    continue;
                }

                _worldObjects.Add(new WorldObject(id++, WorldObjectType.Food, new Vec2(food.transform.position.x, food.transform.position.y)));
            }

            foreach (var bed in _beds)
            {
                if (bed == null)
                {
                    continue;
                }

                _worldObjects.Add(new WorldObject(id++, WorldObjectType.Bed, new Vec2(bed.transform.position.x, bed.transform.position.y)));
            }

            _world.SetObjects(_worldObjects);
        }

        public void RegisterFood(FoodView food)
        {
            if (food == null || _foods.Contains(food))
            {
                return;
            }

            _foods.Add(food);
        }

        public void UnregisterFood(FoodView food)
        {
            if (food == null)
            {
                return;
            }

            _foods.Remove(food);
        }

        public void RegisterBed(BedView bed)
        {
            if (bed == null || _beds.Contains(bed))
            {
                return;
            }

            _beds.Add(bed);
        }

        public void UnregisterBed(BedView bed)
        {
            if (bed == null)
            {
                return;
            }

            _beds.Remove(bed);
        }
    }
}
