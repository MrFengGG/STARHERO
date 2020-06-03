using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace StarHero
{
    class CharacterEntity
    {
        static Texture2D characterTexture;

        Animation walkDown;
        Animation walkUp;
        Animation walkLeft;
        Animation walkRight;

        Animation standDown;
        Animation standUp;
        Animation standLeft;
        Animation standRight;

        bool aKeyDown;
        bool dKeyDown;
        bool wKeyDown;
        bool sKeyDown;

        public float Speed
        {
            get;
            set;
        }

        Animation currentAnimation;


        public float X
        {
            get;
            set;
        }
        public float Y
        {
            get;
            set;
        }
        public CharacterEntity(GraphicsDevice graphicsDevice)
        {
            if(characterTexture == null)
            {
                using (var stream = TitleContainer.OpenStream("Content/charactersheet.png"))
                {
                    characterTexture = Texture2D.FromStream(graphicsDevice, stream);
                }
            }

            walkDown = new Animation();
            walkDown.AddFrame(new Rectangle(0, 0, 16, 16), TimeSpan.FromSeconds(.25));
            walkDown.AddFrame(new Rectangle(16, 0, 16, 16), TimeSpan.FromSeconds(.25));
            walkDown.AddFrame(new Rectangle(0, 0, 16, 16), TimeSpan.FromSeconds(.25));
            walkDown.AddFrame(new Rectangle(32, 0, 16, 16), TimeSpan.FromSeconds(.25));

            walkUp = new Animation();
            walkUp.AddFrame(new Rectangle(144, 0, 16, 16), TimeSpan.FromSeconds(.25));
            walkUp.AddFrame(new Rectangle(160, 0, 16, 16), TimeSpan.FromSeconds(.25));
            walkUp.AddFrame(new Rectangle(144, 0, 16, 16), TimeSpan.FromSeconds(.25));
            walkUp.AddFrame(new Rectangle(176, 0, 16, 16), TimeSpan.FromSeconds(.25));

            walkLeft = new Animation();
            walkLeft.AddFrame(new Rectangle(48, 0, 16, 16), TimeSpan.FromSeconds(.25));
            walkLeft.AddFrame(new Rectangle(64, 0, 16, 16), TimeSpan.FromSeconds(.25));
            walkLeft.AddFrame(new Rectangle(48, 0, 16, 16), TimeSpan.FromSeconds(.25));
            walkLeft.AddFrame(new Rectangle(80, 0, 16, 16), TimeSpan.FromSeconds(.25));

            walkRight = new Animation();
            walkRight.AddFrame(new Rectangle(96, 0, 16, 16), TimeSpan.FromSeconds(.25));
            walkRight.AddFrame(new Rectangle(112, 0, 16, 16), TimeSpan.FromSeconds(.25));
            walkRight.AddFrame(new Rectangle(96, 0, 16, 16), TimeSpan.FromSeconds(.25));
            walkRight.AddFrame(new Rectangle(128, 0, 16, 16), TimeSpan.FromSeconds(.25));

            // Standing animations only have a single frame of animation:
            standDown = new Animation();
            standDown.AddFrame(new Rectangle(0, 0, 16, 16), TimeSpan.FromSeconds(.25));

            standUp = new Animation();
            standUp.AddFrame(new Rectangle(144, 0, 16, 16), TimeSpan.FromSeconds(.25));

            standLeft = new Animation();
            standLeft.AddFrame(new Rectangle(48, 0, 16, 16), TimeSpan.FromSeconds(.25));

            standRight = new Animation();
            standRight.AddFrame(new Rectangle(96, 0, 16, 16), TimeSpan.FromSeconds(.25));

            aKeyDown = false;
            wKeyDown = false;
            sKeyDown = false;
            dKeyDown = false;

            Speed = 100;
            currentAnimation = standDown;
        }

        public void Update(GameTime gameTime)
        {
            // temporary - we'll replace this with logic based off of which way the
            // character is moving when we add movement logic
            KeyboardState state = Keyboard.GetState();
            wKeyDown = state.IsKeyDown(Keys.W);
            sKeyDown = state.IsKeyDown(Keys.S);
            aKeyDown = state.IsKeyDown(Keys.A);
            dKeyDown = state.IsKeyDown(Keys.D);
            if (aKeyDown || dKeyDown || sKeyDown || wKeyDown)
            {
                if (sKeyDown)
                {
                    currentAnimation = walkDown;
                    this.Y += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                if (wKeyDown)
                {
                    currentAnimation = walkUp;
                    this.Y -= Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                if (dKeyDown)
                {
                    currentAnimation = walkRight;
                    this.X += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                if (aKeyDown)
                {
                    currentAnimation = walkLeft;
                    this.X -= Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
            }
            else
            {
                if (currentAnimation == walkRight)
                {
                    currentAnimation = standRight;
                }
                else if (currentAnimation == walkLeft)
                {
                    currentAnimation = standLeft;
                }
                else if (currentAnimation == walkDown)
                {
                    currentAnimation = standDown;
                }
                else if(currentAnimation == walkUp)
                {
                    currentAnimation = standUp;
                }
            }
            currentAnimation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 topLeftOfSprite = new Vector2(this.X, this.Y);
            Color tintColor = Color.White;
            var sourceRectangle = currentAnimation.CurrentRectangle;
            var sourceVec = new Vector2(1, 1);
            var scaleVec = new Vector2(2, 2);
            spriteBatch.Draw(characterTexture, topLeftOfSprite, sourceRectangle, Color.White, 0, sourceVec, scaleVec, SpriteEffects.None, 0);
        }
    }
}
