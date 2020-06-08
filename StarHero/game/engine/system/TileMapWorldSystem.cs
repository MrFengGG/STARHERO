using Microsoft.Xna.Framework;
using StarHero.game.engine.core.components.map;
using StarHero.game.engine.core.system;
using System;

namespace StarHero.game.engine.system
{
    class TileMapWorldSystem : WorldSystem<TileMapComponent>
    {
        public string AddComponent(TileMapComponent t)
        {
            return null;
        }

        public void RemoveComponent(TileMapComponent t)
        {
        }

        public void RemoveComponent(string uid)
        {
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
