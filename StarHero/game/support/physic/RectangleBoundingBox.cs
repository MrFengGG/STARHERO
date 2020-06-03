using Microsoft.Xna.Framework;

namespace StarHero.game.support.physic
{
    //简单2D碰撞组件
    class RectangleBoundingBox : BoxCollider2D
    {

        GameObject gameObject;

        float positionX;

        float positionY;

        protected Rectangle boundingBox;

        public RectangleBoundingBox(GameObject parent, float x, float y, Vector2 size)
        {
            gameObject = parent;
            boundingBox = new Rectangle((int)parent.X, (int)parent.Y, (int)size.X, (int)size.Y);
            boundingBox.Offset(positionX, positionY);
        }

        public void Update(GameTime gameTime)
        {
            boundingBox.X = (int)gameObject.X;
            boundingBox.Y = (int)gameObject.Y;
        }

        public bool isCollider(BoxCollider2D other)
        {
            if(other is RectangleBoundingBox)
            {
                return ((RectangleBoundingBox)other).boundingBox.Intersects(boundingBox);
            }
            return false;
        }

        public float ColloderInDistanceX(BoxCollider2D other, float x)
        {
            // todo
            return x;
        }

        public float ColloderInDistanceY(BoxCollider2D other, float y)
        {
            // todo
            return y;
        }

        public bool IsColliderInDistanceX(BoxCollider2D other, float x)
        {
            if (other is RectangleBoundingBox)
            {
                boundingBox.Offset(x, 0);
                if (((RectangleBoundingBox)other).boundingBox.Intersects(boundingBox))
                {
                    boundingBox.Offset(-x, 0);
                    return true;
                }
            }
            return false;
        }

        public bool IsColliderInDistanceY(BoxCollider2D other, float y)
        {
            if (other is RectangleBoundingBox)
            {
                boundingBox.Offset(0, y);
                if (((RectangleBoundingBox)other).boundingBox.Intersects(boundingBox))
                {
                    boundingBox.Offset(0, -y);
                    return true;
                }
            }
            return false;
        }
    }
}
