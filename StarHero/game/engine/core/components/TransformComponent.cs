using Microsoft.Xna.Framework;

namespace StarHero.game.engine.core.components
{
    class TransformComponent : BaseComponent
    {
        public Vector2 Position { get; set; }

        public Vector2 Scale { get; set; }

        public float Rotation { get; set; }

        public TransformComponent(Vector2 position, Vector2 scale, float rotation)
        {
            Position = position;
            Scale = scale;
            Rotation = rotation;
        }

        public override void Update(GameTime gameTime)
        {
            
        }
    }
}
