


using Microsoft.Xna.Framework;

namespace StarHero.game.engine.core.components
{
    class ColliderComponent : BaseComponent
    {
        public override void Update(GameTime gameTime)
        {

        }

        public bool IsCollider(ColliderComponent other)
        {
            return false;
        }
    }
}
