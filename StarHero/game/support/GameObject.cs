using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StarHero.game.support.physic;
using System.Collections.Generic;

namespace StarHero.game.support
{
    //游戏对象
    abstract class GameObject : GameComponent
    {
        //获取碰撞体
        public BoxCollider2D BoxCollider { get; set; }
        //x坐标
        private float x;
        public float X
        {
            get
            {
                return x;
            }
            set
            {
                float targetX = CanUpdateTargetX(x);
                this.x = targetX;
            }
        }
        //y坐标
        private float y;
        public float Y
        {
            get
            {
                return y;
            }
            set
            {
                float targetY = CanUpdateTargetY(y);
                this.y = targetY;
            }
        }
        //旋转角度
        private float rotation;
        public float Rotation
        {
            get
            {
                return rotation;
            }
            set
            {
                float targetRotation = CanUpdateTargetRotation(value);
                rotation = targetRotation;
            }
        }
        //对象缩放
        public Vector2 Scale
        {
            get
            {
                return Scale;
            }
            set
            {
                if (CanUpdateScale(value))
                {
                    Scale = value;
                }
            }
        }
        //是否为刚体
        public bool IsRigid { get; set; }
        //对象层级
        public int Level { get; set; }
        //销毁对象
        public abstract void Destory();
        //绘制对象
        public abstract void Draw(SpriteBatch spriteBatch);
        //是否激活状态
        public abstract bool IsActive();
        //激活/屏蔽对象
        public abstract void SetActive(bool active);
        //更新对象状态
        public abstract void Update(GameTime gameTime);
        //碰撞回调
        public abstract void OnCollide(GameObject other);
        //对象是否包含指定标签
        public abstract bool ContainsTag(string tag);
        //获取所有标签
        public abstract HashSet<string> GetAllTags();

        //可移动到的合理目标位置
        public abstract float CanUpdateTargetX(float x);
        public abstract float CanUpdateTargetY(float y);
        //可旋转到的目标角度
        public abstract float CanUpdateTargetRotation(float rotation);
        //可旋转到的目标缩放
        public abstract bool CanUpdateScale(Vector2 scale);
    }
}
