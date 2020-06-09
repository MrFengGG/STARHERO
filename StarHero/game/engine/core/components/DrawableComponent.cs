using Microsoft.Xna.Framework.Graphics;

namespace StarHero.game.engine.core.components
{
    abstract class DrawableComponent : BaseComponent
    {
        public abstract void Render(SpriteBatch spriteBatch);
    }
}
