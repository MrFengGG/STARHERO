using StarHero.game.engine.core.components;
using StarHero.game.engine.core.events;
using System.Collections.Generic;

namespace StarHero.game.engine.core.objects
{
    interface GameObject : GameComponent
    {
        //获取子组件
        List<T> GetComponents<T>() where T : GameComponent;

        //获取子组件
        T GetComponent<T>() where T : GameComponent;

        //获取父节点子组件
        List<T> GetParentComponents<T>() where T : GameComponent;

        //获取父节点子组件
        T GetParentComponent<T>() where T : GameComponent;

        void AddComponent<T>(T component) where T : GameComponent;

        //响应事件
        void OnEvent(Event gameEvent);
    }
}
