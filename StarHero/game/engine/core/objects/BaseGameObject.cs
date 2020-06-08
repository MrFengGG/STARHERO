using System;
using System.Collections.Generic;
using StarHero.game.engine.core.components;
using StarHero.game.engine.core.events;

namespace StarHero.game.engine.core.objects
{
    class BaseGameObject : GameObject
    {
        BaseGameObject parent;

        List<GameComponent> gameComponents = new List<components.GameComponent>();

        private bool isActive;

        public void Active()
        {
            isActive = true;
        }

        public T GetComponent<T>() where T : components.GameComponent
        {
            foreach(GameComponent component in gameComponents)
            {
                if (component.GetType().Equals(typeof(T))){
                    return (T) component;
                }
            }
            return default(T);
        }

        public List<T> GetComponents<T>() where T : components.GameComponent
        {
            List<T> components = new List<T>();
            foreach (GameComponent component in gameComponents)
            {
                if (component.GetType().Equals(typeof(T)))
                {
                    components.Add((T)component);
                }
            }
            return components;
        }

        public GameObject GetParent()
        {
            return parent;
        }

        public T GetParentComponent<T>() where T : components.GameComponent
        {
            return parent.GetComponent<T>();
        }

        public List<T> GetParentComponents<T>() where T : components.GameComponent
        {
            return parent.GetComponents<T>();
        }

        public void Inactive()
        {
            isActive = false;
        }

        public bool IsActive()
        {
            return isActive;
        }

        public void OnEvent(Event gameEvent)
        {
            throw new NotImplementedException();
        }

        public void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
