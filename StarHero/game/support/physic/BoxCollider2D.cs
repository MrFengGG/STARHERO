
using Microsoft.Xna.Framework;

namespace StarHero.game.support.physic
{
    interface BoxCollider2D : GameComponent
    {
        //是否发生碰撞
        bool isCollider(BoxCollider2D other);
        //X轴移动一段距离会发生碰撞的点
        float ColloderInDistanceX(BoxCollider2D other, float x);
        //Y轴移动一段距离会发生碰撞的点
        float ColloderInDistanceY(BoxCollider2D other, float y);
        //X轴移动一段距离之后是否会发生碰撞
        bool IsColliderInDistanceX(BoxCollider2D other, float x);
        //Y轴移动一段距离之后是否会发生碰撞
        bool IsColliderInDistanceY(BoxCollider2D other, float y);
    }
}
