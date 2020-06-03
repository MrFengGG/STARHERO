using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StarHero.game.engine.system;

namespace StarHero.game.engine.support
{
    class World
    {
        public SpiriteWorldSystem SpiriteWorldSystem;

        public PhysicWorldSystem PhysicWorldSystem;

        public ColliderWorldSystem ColliderWorldSystem;

        public ObjectWorldSystem ObjectWorldSystem;

        public void Update(GameTime gameTime)
        {
            ObjectWorldSystem.Update(gameTime);

            PhysicWorldSystem.Update(gameTime);
            ColliderWorldSystem.Update(gameTime);
            ObjectWorldSystem.Update(gameTime);
        }

        public void Render(SpriteBatch spriteBatch)
        {
            SpiriteWorldSystem.Render(spriteBatch);
        }
    }
}
