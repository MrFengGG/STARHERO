using Microsoft.Xna.Framework;

namespace StarHero.game.engine.core.components
{
    class TransformComponent : BaseComponent
    {
        public Vector2 Position { get; set; }

        public Vector2 Scale { get; set; }

        public float Rotation { get; set; }

        public override void Update(GameTime gameTime)
        {
            
        }
    }
}
