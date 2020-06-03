using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StarHero.game.support.manager;
using StarHero.game.support.spirite;

namespace StarHero.game.support
{
    class BaseGameObject : GameObject
    {
        protected World world;

        public BaseGameObject(World world)
        {
            this.world = world;
        }

        private List<GameComponent> componentList = new List<GameComponent>();

        private List<GameObject> childList = new List<GameObject>();

        private HashSet<string> tagSet = new HashSet<string>();

        public Spirite CurrentSpirite { get; set; }

        public float Depth { get; set; }

        private bool isActive = true;


        public override void Destory()
        {
            world.DestoryGameObj(this);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach(GameObject child in childList)
            {
                child.Draw(spriteBatch);
            }
            if (CurrentSpirite != null)
            {
                CurrentSpirite.Draw(spriteBatch, new Vector2(X, Y), Color.White, Scale, Rotation, Depth);
            }
        }

        public override bool IsActive()
        {
            return isActive;
        }

        public override void SetActive(bool active)
        {
            isActive = active;
        }

        public override void Update(GameTime gameTime) { }

        public override void OnCollide(GameObject other){ }

        public override bool ContainsTag(string tag)
        {
            return tagSet.Contains(tag);
        }

        public override HashSet<string> GetAllTags()
        {
            return new HashSet<string>(tagSet);
        }

        public override float CanUpdateTargetX(float x)
        {
            return world.moveTargetX(this, x);
        }

        public override float CanUpdateTargetY(float y)
        {
            return world.moveTargetY(this, y);
        }

        public override float CanUpdateTargetRotation(float rotation)
        {
            return rotation;
        }

        public override bool CanUpdateScale(Vector2 scale)
        {
            return false;
        }
    }
}
