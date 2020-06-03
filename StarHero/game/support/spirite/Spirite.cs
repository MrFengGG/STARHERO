using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StarHero.game.support.spirite
{
    class Spirite : GameComponent
    {
        public Texture2D Texture { get; set; }

        private Rectangle rectangle;

        public Spirite(Texture2D texture)
        {
            Texture = texture;
            rectangle = new Rectangle(0, 0, texture.Width, texture.Height);
        }

        public Spirite(Texture2D texture, Rectangle rectangle)
        {
            Texture = texture;
            this.rectangle = rectangle;
        }

        public void Draw(SpriteBatch batch, Vector2 position, Color color, Vector2 scale, float rotation, float depth)
        {
            batch.Draw(Texture, position, rectangle, color, rotation, new Vector2(1, 1), scale, SpriteEffects.None, depth);batch.Draw(Texture, position, rectangle, color, rotation, new Vector2(1, 1), scale, SpriteEffects.None, depth);batch.Draw(Texture, position, rectangle, color, rotation, new Vector2(1, 1), scale, SpriteEffects.None, depth);batch.Draw(Texture, position, rectangle, color, rotation, new Vector2(1, 1), scale, SpriteEffects.None, depth);
        }

        public void Update(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }
    }
}
