using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StarHero.game.engine.core.components;
using StarHero.game.engine.core.system;
using System;

namespace StarHero.game.engine.system
{
    class SpiriteWorldSystem : WorldSystem<DrawableComponent>
    {
        public void Render(SpriteBatch spriteBatch)
        {
            foreach(DrawableComponent component in componentSet)
            {
                component.Render(spriteBatch);
            }
        }
    }
}
