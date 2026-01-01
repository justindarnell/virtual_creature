using UnityEngine;

namespace VirtualLife.UnityAdapter
{
    [RequireComponent(typeof(SpriteRenderer))]
    public sealed class FoodView : MonoBehaviour
    {
        private SimRunner _runner;

        private void Awake()
        {
            var renderer = GetComponent<SpriteRenderer>();
            if (renderer.sprite == null)
            {
                renderer.sprite = SpriteFactory.CreateSolid(new Color(0.95f, 0.7f, 0.2f));
            }
        }

        private void OnEnable()
        {
            if (_runner == null)
            {
                _runner = FindObjectOfType<SimRunner>();
            }

            _runner?.RegisterFood(this);
        }

        private void OnDisable()
        {
            _runner?.UnregisterFood(this);
        }
    }
}
