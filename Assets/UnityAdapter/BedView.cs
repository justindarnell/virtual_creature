using UnityEngine;

namespace VirtualLife.UnityAdapter
{
    [RequireComponent(typeof(SpriteRenderer))]
    public sealed class BedView : MonoBehaviour
    {
        private void Awake()
        {
            var renderer = GetComponent<SpriteRenderer>();
            if (renderer.sprite == null)
            {
                renderer.sprite = SpriteFactory.CreateSolid(new Color(0.4f, 0.6f, 0.95f));
            }
        }
    }
}
