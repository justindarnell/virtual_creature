using UnityEngine;

namespace VirtualLife.UnityAdapter
{
    [RequireComponent(typeof(SpriteRenderer))]
    public sealed class BedView : MonoBehaviour
    {
        private SimRunner _runner;

        private void Awake()
        {
            var renderer = GetComponent<SpriteRenderer>();
            if (renderer.sprite == null)
            {
                renderer.sprite = SpriteFactory.CreateSolid(new Color(0.4f, 0.6f, 0.95f));
            }
        }

        private void OnEnable()
        {
            if (_runner == null)
            {
                _runner = FindObjectOfType<SimRunner>();
            }

            _runner?.RegisterBed(this);
        }

        private void OnDisable()
        {
            _runner?.UnregisterBed(this);
        }
    }
}
