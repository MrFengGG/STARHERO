using StarHero.game.engine.core.components;
using System;

namespace StarHero.game.engine.core.system
{
    interface WorldSystem<T> where T : GameComponent
    {
        //更新系统状态
        void Update(Microsoft.Xna.Framework.GameTime gameTime);
        //向系统中增加组件
        String AddComponent(T t);
        //从系统中移除组件
        void RemoveComponent(T t);
        //从系统中移除组件
        void RemoveComponent(String uid);
    }
}
