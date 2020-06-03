using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StarHero.resources;

namespace StarHero.game.character
{
    class Character : Activist
    {
        //聚合纹理
        private Texture2D multiTexture;
        //移动精灵
        MultiSpirite moveUpSpirite;
        MultiSpirite moveDownSpirite;
        MultiSpirite moveLeftSpirite;
        MultiSpirite moveRightSpirite;
        //静止精灵
        MultiSpirite stopUpSpirite;
        MultiSpirite stopDownSpirite;
        MultiSpirite stopLeftSpirite;
        MultiSpirite stopRightSpirite;
        //按键状态
        bool aKeyDown = false;
        bool dKeyDown = false;
        bool sKeyDown = false;
        bool wKeyDown = false;
        bool shiftDown = false;


        public Character(GraphicsDevice graphicsDevice, Vector2 position, float xSpeed, float ySpeed)
        {
            //位置
            Position = position;
            //大小
            Height = 48;
            Width = 48;
            //纹理缩放
            Scale = new Vector2(Height / 16, Width / 16);
            //速度
            XSpeed = xSpeed;
            YSpeed = ySpeed;
            RotateSpeed = 0;
            //初始化动画
            multiTexture = ResourceLoader.loadTexture2D(graphicsDevice, "character", "Content/character.png");
            moveDownSpirite = new MultiSpirite(multiTexture);
            moveDownSpirite.AddFrame(new Rectangle(0, 0, 16, 16));
            moveDownSpirite.AddFrame(new Rectangle(16, 0, 16, 16));
            moveDownSpirite.AddFrame(new Rectangle(0, 0, 16, 16));
            moveDownSpirite.AddFrame(new Rectangle(32, 0, 16, 16));
            moveUpSpirite = new MultiSpirite(multiTexture);
            moveUpSpirite.AddFrame(new Rectangle(144, 0, 16, 16));
            moveUpSpirite.AddFrame(new Rectangle(160, 0, 16, 16));
            moveUpSpirite.AddFrame(new Rectangle(144, 0, 16, 16));
            moveUpSpirite.AddFrame(new Rectangle(176, 0, 16, 16));
            moveLeftSpirite = new MultiSpirite(multiTexture);
            moveLeftSpirite.AddFrame(new Rectangle(48, 0, 16, 16));
            moveLeftSpirite.AddFrame(new Rectangle(64, 0, 16, 16));
            moveLeftSpirite.AddFrame(new Rectangle(48, 0, 16, 16));
            moveLeftSpirite.AddFrame(new Rectangle(80, 0, 16, 16));
            moveRightSpirite = new MultiSpirite(multiTexture);
            moveRightSpirite.AddFrame(new Rectangle(96, 0, 16, 16));
            moveRightSpirite.AddFrame(new Rectangle(112, 0, 16, 16));
            moveRightSpirite.AddFrame(new Rectangle(96, 0, 16, 16));
            moveRightSpirite.AddFrame(new Rectangle(128, 0, 16, 16));
            stopDownSpirite = new MultiSpirite(multiTexture);
            stopDownSpirite.AddFrame(new Rectangle(0, 0, 16, 16));
            stopUpSpirite = new MultiSpirite(multiTexture);
            stopUpSpirite.AddFrame(new Rectangle(144, 0, 16, 16));
            stopLeftSpirite = new MultiSpirite(multiTexture);
            stopLeftSpirite.AddFrame(new Rectangle(48, 0, 16, 16));
            stopRightSpirite = new MultiSpirite(multiTexture);
            stopRightSpirite.AddFrame(new Rectangle(96, 0, 16, 16));
            //初始化当前要显示的精灵
            CurrentSpirite = stopDownSpirite;
        }
        public override void Update(GameTime gameTime)
        {
            updateKeyState(gameTime);
        }

        private void updateKeyState(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();
            //冲刺加速
            shiftDown = state.IsKeyDown(Keys.LeftShift);
            float runSpeedUp = shiftDown ? 5 : 1;
            //移动按键
            wKeyDown = state.IsKeyDown(Keys.W);
            sKeyDown = state.IsKeyDown(Keys.S);
            aKeyDown = state.IsKeyDown(Keys.A);
            dKeyDown = state.IsKeyDown(Keys.D);
            float nextY = this.Position.Y;
            float nextX = this.Position.X;
            if (aKeyDown || dKeyDown || sKeyDown || wKeyDown)
            {
                if (sKeyDown)
                {
                    CurrentSpirite = moveDownSpirite;
                    nextY += runSpeedUp * YSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                if (wKeyDown)
                {
                    CurrentSpirite = moveUpSpirite;
                    nextY -= runSpeedUp * YSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                if (dKeyDown)
                {
                    CurrentSpirite = moveRightSpirite;
                    nextX += runSpeedUp * XSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                if (aKeyDown)
                {
                    CurrentSpirite = moveLeftSpirite;
                    nextX -= runSpeedUp * XSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
            }
            else
            {
                if (CurrentSpirite == moveRightSpirite)
                {
                    CurrentSpirite = stopRightSpirite;
                }
                else if (CurrentSpirite == moveLeftSpirite)
                {
                    CurrentSpirite = stopLeftSpirite;
                }
                else if (CurrentSpirite == moveDownSpirite)
                {
                    CurrentSpirite = stopDownSpirite;
                }
                else if (CurrentSpirite == moveUpSpirite)
                {
                    CurrentSpirite = stopUpSpirite;
                }
            }
            CurrentSpirite.UpdateTimeSpan(shiftDown ? 0.1 : 0.25);

            position.X = nextX;
            position.Y = nextY;
            CurrentSpirite.Update(gameTime);
        }
    }
}
