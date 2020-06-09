using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StarHero.game.engine.core.objects;
using System;
using System.Collections.Generic;

namespace StarHero.game.engine.core.components.animation
{
    class AnimationComponent : DrawableComponent
    {
        public Texture2D Texture { get; set; }

        public Color TextureColor { get; set; }

        public float Depth { get; set; }

        public Vector2 Origin { get; set; }

        public Vector2 Position { get; set; }

        //精灵列表
        List<AnimationFrame> frames = new List<AnimationFrame>();
        //当前动画时间
        TimeSpan timeIntoAnimation;
        //每个精灵显示时间
        TimeSpan frameSpan = TimeSpan.FromSeconds(.25);
        //动画总时间
        TimeSpan Duration
        {
            get
            {
                return TimeSpan.FromSeconds(frameSpan.TotalSeconds * frames.Count);
            }
        }
        //更新每帧显示时间,值越小,动画播放速度越快
        public void UpdateTimeSpan(double value)
        {
            if (value != frameSpan.TotalSeconds)
            {
                frameSpan = value > 0 ? TimeSpan.FromSeconds(value) : frameSpan;
            }
        }
        //新增帧
        public AnimationComponent AddFrame(AnimationFrame frame)
        {
            frames.Add(frame);
            return this;
        }
        public AnimationComponent(GameObject parent, AnimationFrame firstFrame)
        {
            this.parentGameObject = parent;
            frames.Add(firstFrame);
            Depth = 0.1f;
            TextureColor = Color.White;
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            AnimationFrame currentFrame = getCurrentFrame();
            if (currentFrame != null)
            {
                TransformComponent transform = GetParent().GetComponent<TransformComponent>();
                spriteBatch.Draw(currentFrame.Texture, transform.Position + Position, currentFrame.Rectangle, TextureColor,
                    transform.Rotation, Origin, transform.Scale, SpriteEffects.None, Depth);
            }

        }

        public override void Update(GameTime gameTime)
        {
            double secondsIntoAnimation = timeIntoAnimation.TotalSeconds + gameTime.ElapsedGameTime.TotalSeconds;

            double remainder = secondsIntoAnimation % Duration.TotalSeconds;

            timeIntoAnimation = TimeSpan.FromSeconds(remainder);
        }

        //获取当前精灵
        private AnimationFrame getCurrentFrame()
        {
            AnimationFrame currentFrame = null;
            TimeSpan accumulatedTime = new TimeSpan();
            foreach (var spirite in frames)
            {
                if (accumulatedTime + frameSpan >= timeIntoAnimation)
                {
                    currentFrame = spirite;
                    break;
                }
                else
                {
                    accumulatedTime += frameSpan;
                }
            }
            return currentFrame;
        }
    }
}
