using System.Collections.Generic;
using UnityEngine;

namespace VirtualLife.UnityAdapter
{
    public static class SpriteFactory
    {
        private static readonly Dictionary<Color32, Sprite> SpriteCache = new Dictionary<Color32, Sprite>();

        public static Sprite CreateSolid(Color color)
        {
            var key = (Color32)color;
            if (SpriteCache.TryGetValue(key, out var cached))
            {
                return cached;
            }

            var texture = new Texture2D(1, 1)
            {
                filterMode = FilterMode.Point
            };
            texture.SetPixel(0, 0, color);
            texture.Apply();

            var sprite = Sprite.Create(texture, new Rect(0, 0, 1, 1), new Vector2(0.5f, 0.5f), 1f);
            Object.DontDestroyOnLoad(texture);
            Object.DontDestroyOnLoad(sprite);
            SpriteCache[key] = sprite;
            return sprite;
        }
    }
}
