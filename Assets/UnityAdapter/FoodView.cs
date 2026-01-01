using UnityEngine;

namespace VirtualLife.UnityAdapter
{
    [RequireComponent(typeof(SpriteRenderer))]
    public sealed class FoodView : MonoBehaviour
    {
        private void Awake()
        {
            var renderer = GetComponent<SpriteRenderer>();
            if (renderer.sprite == null)
            {
                renderer.sprite = SpriteFactory.CreateSolid(new Color(0.95f, 0.7f, 0.2f));
            }
        }
    }
}
