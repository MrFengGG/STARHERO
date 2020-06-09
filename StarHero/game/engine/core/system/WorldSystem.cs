using Microsoft.Xna.Framework;
using StarHero.game.engine.core.components;
using System;
using System.Collections.Generic;

namespace StarHero.game.engine.core.system
{
    abstract class WorldSystem<T> where T : components.GameComponent
    {
        protected HashSet<T> componentSet = new HashSet<T>();

        //向系统中增加组件
        public String AddComponent(T t)
        {
            componentSet.Add(t);
            return "";
        }
        //从系统中移除组件
        public void RemoveComponent(T t)
        {
            componentSet.Remove(t);
        }
        //从系统中移除组件
        public void RemoveComponent(String uid)
        {

        }

        public void Update(GameTime gameTime)
        {
            foreach(T t in componentSet)
            {
                t.Update(gameTime);
            }
        }
    }
}
