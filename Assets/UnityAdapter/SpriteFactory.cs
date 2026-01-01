using UnityEngine;

namespace VirtualLife.UnityAdapter
{
    public static class SpriteFactory
    {
        public static Sprite CreateSolid(Color color)
        {
            var texture = new Texture2D(1, 1)
            {
                filterMode = FilterMode.Point
            };
            texture.SetPixel(0, 0, color);
            texture.Apply();
            return Sprite.Create(texture, new Rect(0, 0, 1, 1), new Vector2(0.5f, 0.5f), 1f);
        }
    }
}
