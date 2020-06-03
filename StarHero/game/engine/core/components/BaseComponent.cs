using Microsoft.Xna.Framework;
using StarHero.game.engine.core.objects;

namespace StarHero.game.engine.core.components
{
    abstract class BaseComponent : GameComponent
    {
        protected bool isActive;

        protected GameObject parentGameObject;

        public void Active()
        {
            isActive = true;
        }

        public GameObject GetParent()
        {
            return parentGameObject;
        }

        public void Inactive()
        {
            isActive = false;
        }

        public bool IsActive()
        {
            return isActive;
        }

        public abstract void Update(GameTime gameTime);
    }
}
