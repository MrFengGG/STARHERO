using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace StarHero
{
    //地形方块
    abstract class TopographyBlock
    {
        //方块宽度
        public static float width = 100;
        //方块高度
        public static float height = 100;
        //缩放，默认不缩放
        protected Vector2 scale = new Vector2(1, 1);

        Vector2 origin = new Vector2(1, 1);

        //地区名称
        protected String areaName
        {
            get;set;
        }

        public abstract Texture2D GetTexture();

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            spriteBatch.Draw(GetTexture(), position, null, color, 0, origin, scale, SpriteEffects.None, 0);
        }
    }
}
