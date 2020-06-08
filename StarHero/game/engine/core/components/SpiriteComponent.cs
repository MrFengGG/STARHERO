
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StarHero.game.engine.core.objects;

namespace StarHero.game.engine.core.components
{
    class SpiriteComponent : BaseComponent
    {
        public Texture2D Texture { get; set; }

        public Rectangle SourceRectangle { get; set; }

        public Color TextureColor { get; set; }

        public float Depth { get; set; }

        public Vector2 Origin { get; set; }

        public Vector2 Position { get; set; }

        public SpiriteComponent(Texture2D texture, GameObject parent)
        {
            this.parentGameObject = parent;
            Texture = texture;
            TextureColor = Color.White;
            Depth = 0.5f;
            Origin = new Vector2(1, 1);
            SourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
        }

        public override void Update(GameTime gameTime)
        {

        }

        public virtual void Render(SpriteBatch spriteBatch)
        {
            TransformComponent transform = GetParent().GetComponent<TransformComponent>();
            spriteBatch.Draw(Texture, transform.Position + Position, SourceRectangle, TextureColor, 
                transform.Rotation, Origin, transform.Scale, SpriteEffects.None, Depth);
        }
    }
}
