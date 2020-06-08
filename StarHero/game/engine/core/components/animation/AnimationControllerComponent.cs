
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StarHero.game.engine.core.objects;
using System.Collections.Generic;

namespace StarHero.game.engine.core.components.animation
{
    class AnimationControllerComponent : BaseComponent
    {
        Dictionary<string, AnimationComponent> animationMap = new Dictionary<string, AnimationComponent>();

        private AnimationComponent currentAnimation;

        public AnimationControllerComponent(GameObject parent, string name, AnimationComponent firstAnimation)
        {
            animationMap[name] = firstAnimation;
            currentAnimation = firstAnimation;
            this.parentGameObject = parent;
        }
        //增加动画
        public AnimationControllerComponent AddAnimation(string name, AnimationComponent animation)
        {
            animationMap[name] = animation;
            return this;
        }
        //播放对应动画
        public AnimationControllerComponent PlayAnimation(string name)
        {
            if (animationMap.ContainsKey(name))
            {
                currentAnimation = animationMap[name];
            }
            return this;
        }

        public override void Update(GameTime gameTime)
        {
            currentAnimation.Update(gameTime);
        }

        public void Render(SpriteBatch spriteBatch)
        {
            currentAnimation.Render(spriteBatch);
        }
    }
}
