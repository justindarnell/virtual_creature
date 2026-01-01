using UnityEngine;
using VirtualLife.SimCore;

namespace VirtualLife.UnityAdapter
{
    public sealed class DebugOverlay : MonoBehaviour
    {
        [SerializeField] private SimRunner simRunner;

        private void Awake()
        {
            if (simRunner == null)
            {
                simRunner = FindObjectOfType<SimRunner>();
            }
        }

        private void OnGUI()
        {
            if (simRunner == null || simRunner.Creature == null)
            {
                return;
            }

            var creature = simRunner.Creature;
            var drives = creature.Drives;
            GUI.Label(new Rect(10, 10, 400, 20), $"Action: {creature.CurrentAction}");
            GUI.Label(new Rect(10, 30, 400, 20), $"Hunger: {drives.Hunger:0.00}");
            GUI.Label(new Rect(10, 50, 400, 20), $"Fatigue: {drives.Fatigue:0.00}");
            GUI.Label(new Rect(10, 70, 400, 20), $"Target: {creature.CurrentTarget}");
        }
    }
}
