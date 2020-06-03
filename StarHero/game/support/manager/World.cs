using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StarHero.game.support.manager
{
    class World : GameComponent
    {
        protected HashSet<GameObject> objectSet = new HashSet<GameObject>();

        public Map CurrentMap { get; set; }

        public World AddGameObject(GameObject gameObject)
        {
            objectSet.Add(gameObject);
            return this;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(CurrentMap != null)
            {
                CurrentMap.Draw(spriteBatch, );
            }
            foreach (GameObject gameObject in objectSet)
            {
                if (gameObject.IsActive())
                {
                    gameObject.Draw(spriteBatch);
                }
            }
        }

        public void DestoryGameObj(GameObject gameObject)
        {
            objectSet.Remove(gameObject);
        }

        public bool IsActive()
        {
            throw new NotImplementedException();
        }

        public void SetActive(bool active)
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            foreach (GameObject gameObject in objectSet)
            {
                if (gameObject.IsActive())
                {
                    gameObject.Update(gameTime);
                }
            }
            handleColliding();
        }

        public bool PositionHasColliding(GameObject game)
        {
            return false;
        }

        public float moveTargetX(GameObject game, float x)
        {
            return x;
        }

        public float moveTargetY(GameObject game, float y)
        {
            return y;
        }

        private void handleColliding()
        {
            // todo 处理碰撞
        }
    }
}
