using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StarHero.resources;

namespace StarHero
{
    class Land : TopographyBlock
    {
        static Texture2D texture;

        public Land(GraphicsDevice graphicsDevice, String area)
        {
            texture = ResourceLoader.GetTexture("land");
            scale = new Vector2(width / texture.Width, height / texture.Height);
            this.areaName = area;
        }

        public override Texture2D GetTexture()
        {
            return texture;
        }
    }
}
