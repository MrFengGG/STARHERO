﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace StarHero.game.engine.resources
{
    class ResourceLoader
    {
        private static Dictionary<String, Texture2D> textureDict = new Dictionary<String, Texture2D>();

        //获取纹理
        public static Texture2D GetTexture(String textureName)
        {
            return textureDict[textureName];
        }

        //加载纹理
        public static Texture2D LoadTexture2D(GraphicsDevice graphicsDevice, String textureName, String texturePath)
        {
            using (var stream = TitleContainer.OpenStream(texturePath))
            {
                Texture2D texture = Texture2D.FromStream(graphicsDevice, stream);
                textureDict[textureName] = texture;
                return texture;
            }
        }

    }
}
