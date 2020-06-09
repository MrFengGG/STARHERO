using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StarHero.game.engine.core.components;
using StarHero.game.engine.core.components.animation;
using StarHero.game.engine.core.objects;
using StarHero.game.engine.resources;

namespace StarHero.game.test
{
    class TestGameObject : BaseGameObject
    {
        private AnimationControllerComponent animationController;

        //聚合纹理
        private Texture2D multiTexture;
        //按键状态
        bool aKeyDown = false;
        bool dKeyDown = false;
        bool sKeyDown = false;
        bool wKeyDown = false;
        bool shiftDown = false;

        public TestGameObject(GraphicsDevice graphicsDevice)
        {
            multiTexture = ResourceLoader.LoadTexture2D(graphicsDevice, "character", "Content/character.png");
            AnimationComponent moveDownAnimation = new AnimationComponent(this, new AnimationFrame(multiTexture, new Rectangle(0, 0, 16, 16)));
            moveDownAnimation.AddFrame(new AnimationFrame(multiTexture, new Rectangle(16, 0, 16, 16)));
            moveDownAnimation.AddFrame(new AnimationFrame(multiTexture, new Rectangle(0, 0, 16, 16)));
            moveDownAnimation.AddFrame(new AnimationFrame(multiTexture, new Rectangle(32, 0, 16, 16)));

            AnimationComponent moveUpAnimation = new AnimationComponent(this, new AnimationFrame(multiTexture, new Rectangle(144, 0, 16, 16)));
            moveUpAnimation.AddFrame(new AnimationFrame(multiTexture, new Rectangle(160, 0, 16, 16)));
            moveUpAnimation.AddFrame(new AnimationFrame(multiTexture, new Rectangle(144, 0, 16, 16)));
            moveUpAnimation.AddFrame(new AnimationFrame(multiTexture, new Rectangle(176, 0, 16, 16)));

            AnimationComponent moveLeftAnimation = new AnimationComponent(this, new AnimationFrame(multiTexture, new Rectangle(48, 0, 16, 16)));
            moveLeftAnimation.AddFrame(new AnimationFrame(multiTexture, new Rectangle(48, 0, 16, 16)));
            moveLeftAnimation.AddFrame(new AnimationFrame(multiTexture, new Rectangle(64, 0, 16, 16)));
            moveLeftAnimation.AddFrame(new AnimationFrame(multiTexture, new Rectangle(48, 0, 16, 16)));
            moveLeftAnimation.AddFrame(new AnimationFrame(multiTexture, new Rectangle(80, 0, 16, 16)));

            AnimationComponent moveRightAnimation = new AnimationComponent(this, new AnimationFrame(multiTexture, new Rectangle(96, 0, 16, 16)));
            moveRightAnimation.AddFrame(new AnimationFrame(multiTexture, new Rectangle(112, 0, 16, 16)));
            moveRightAnimation.AddFrame(new AnimationFrame(multiTexture, new Rectangle(96, 0, 16, 16)));
            moveRightAnimation.AddFrame(new AnimationFrame(multiTexture, new Rectangle(128, 0, 16, 16)));

            AnimationComponent stopDownAnimation  = new AnimationComponent(this, new AnimationFrame(multiTexture, new Rectangle(0, 0, 16, 16)));
            AnimationComponent stopUpAnimation = new AnimationComponent(this, new AnimationFrame(multiTexture, new Rectangle(144, 0, 16, 16)));
            AnimationComponent stopLeftAnimation = new AnimationComponent(this, new AnimationFrame(multiTexture, new Rectangle(48, 0, 16, 16)));
            AnimationComponent stopRightAnimation = new AnimationComponent(this, new AnimationFrame(multiTexture, new Rectangle(96, 0, 16, 16)));

            animationController = new AnimationControllerComponent(this, "moveUp", moveUpAnimation);
            animationController.AddAnimation("moveDown", moveDownAnimation);
            animationController.AddAnimation("moveLeft", moveLeftAnimation);
            animationController.AddAnimation("moveRight", moveRightAnimation);

            animationController.AddAnimation("stopDown", stopDownAnimation);
            animationController.AddAnimation("stopUp", stopUpAnimation);
            animationController.AddAnimation("stopLeft", stopLeftAnimation);
            animationController.AddAnimation("stopRight", stopRightAnimation);

            animationController.PlayAnimation("moveLeft");

            TransformComponent transform = new TransformComponent(new Vector2(100, 1), new Vector2(1, 1), 0);
            AddComponent(transform);
            AddComponent(animationController);
        }

    }
}
