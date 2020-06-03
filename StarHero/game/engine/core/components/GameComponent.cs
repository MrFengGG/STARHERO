
using Microsoft.Xna.Framework;
using StarHero.game.engine.core.objects;

namespace StarHero.game.engine.core.components
{
    interface GameComponent
    {
        //更新组件状态
        void Update(GameTime gameTime);
        //激活组件
        void Active();
        //关闭组件
        void Inactive();
        //组件是否处于激活状态
        bool IsActive();
        //获取持有组件的对象
        GameObject GetParent();
    }
}
