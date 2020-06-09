using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StarHero.game.engine.core.components;
using StarHero.game.engine.core.objects;
using StarHero.game.engine.system;

namespace StarHero.game.engine.support
{
    class World
    {
        SpiriteWorldSystem spiriteWorldSystem;

        PhysicWorldSystem physicWorldSystem;

        ColliderWorldSystem colliderWorldSystem;

        ObjectWorldSystem objectWorldSystem;

        public World()
        {
            spiriteWorldSystem = new SpiriteWorldSystem();
            physicWorldSystem = new PhysicWorldSystem();
            colliderWorldSystem = new ColliderWorldSystem();
            objectWorldSystem = new ObjectWorldSystem();
        }

        public void AddComponent(core.components.GameComponent gameComponent)
        {
            DrawableComponent spiriteComponent = gameComponent as DrawableComponent;
            if(spiriteComponent != null)
            {
                spiriteWorldSystem.AddComponent(spiriteComponent);
            }
            GameObject gameObject = gameComponent as GameObject;
            if(gameObject != null)
            {
                objectWorldSystem.AddComponent(gameObject);
            }
        }

        public void Update(GameTime gameTime)
        {
            objectWorldSystem.Update(gameTime);
            physicWorldSystem.Update(gameTime);
            colliderWorldSystem.Update(gameTime);
            objectWorldSystem.Update(gameTime);
            spiriteWorldSystem.Update(gameTime);
        }

        public void Render(SpriteBatch spriteBatch)
        {
            spiriteWorldSystem.Render(spriteBatch);
        }
    }
}
