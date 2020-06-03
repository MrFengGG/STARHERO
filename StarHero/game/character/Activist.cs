
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StarHero.game.character
{
    //可移动对象
    abstract class Activist
    {
        protected Vector2 position;
        public Vector2 Position { get { return position; } set { position = value; } }

        public float Height { get; set; }

        public float Width { get; set; }

        public Vector2 Scale { get; set; }

        public float XSpeed{ get; set; }

        public float YSpeed { get; set; }

        public float RotateSpeed { get; set; }

        public MultiSpirite CurrentSpirite { get; set; }

        public abstract void Update(GameTime gameTime);

        public void Draw(SpriteBatch spriteBatch)
        {
            CurrentSpirite.Draw(spriteBatch, Position, Color.White, Scale);
        }
    }
}
