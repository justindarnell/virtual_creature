using UnityEngine;
using VirtualLife.SimCore;

namespace VirtualLife.UnityAdapter
{
    [RequireComponent(typeof(SpriteRenderer))]
    public sealed class CreatureView : MonoBehaviour
    {
        private SpriteRenderer _renderer;

        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
            if (_renderer.sprite == null)
            {
                _renderer.sprite = SpriteFactory.CreateSolid(new Color(0.2f, 0.8f, 0.3f));
            }
        }

        public void ApplyPosition(Vec2 position)
        {
            transform.position = new Vector3(position.X, position.Y, transform.position.z);
        }
    }
}
