using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StarHero.game.support.spirite;
using System;
using System.Collections.Generic;

namespace StarHero.game.support.animation
{
    class Animation : GameComponent
    {

        //精灵列表
        List<Spirite> frames = new List<Spirite>();
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
        //更新精灵显示时间,值越小,动画播放速度越快
        public void UpdateTimeSpan(double value)
        {
            if (value != frameSpan.TotalSeconds)
            {
                frameSpan = value > 0 ? TimeSpan.FromSeconds(value) : frameSpan;
            }
        }
        //新增精灵
        public Animation AddFrame(Spirite spirite)
        {
            frames.Add(spirite);
            return this;
        }

        public void Update(GameTime gameTime)
        {
            double secondsIntoAnimation =
                timeIntoAnimation.TotalSeconds + gameTime.ElapsedGameTime.TotalSeconds;

            double remainder = secondsIntoAnimation % Duration.TotalSeconds;

            timeIntoAnimation = TimeSpan.FromSeconds(remainder);
        }
        //绘制动画
        public void Draw(SpriteBatch batch, Vector2 position, Color color, Vector2 scale, float rotation, float depth)
        {
            Spirite currentSpirite = getCurrentSpirite();
            if(currentSpirite != null)
            {
                currentSpirite.Draw(batch, position, color, scale, rotation, depth);
            }
        }

        //获取当前精灵
        private Spirite getCurrentSpirite()
        {
            Spirite currentSpirite = null;
            TimeSpan accumulatedTime = new TimeSpan();
            foreach (var spirite in frames)
            {
                if (accumulatedTime + frameSpan >= timeIntoAnimation)
                {
                    currentSpirite = spirite;
                    break;
                }
                else
                {
                    accumulatedTime += frameSpan;
                }
            }
            return currentSpirite;
        }
    }
}
