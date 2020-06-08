
using Microsoft.Xna.Framework;
using StarHero.game.engine.core.objects;

namespace StarHero.game.engine.core.components
{
    class CameraComponent : BaseComponent
    {
        //缩放
        public float Zoom { get; set; }
        //旋转角度
        public float Rotation { get; set; }
        //位置
        Vector2 Position { get; set; }
        //变换矩阵
        private Matrix transform;
        //获取变换矩阵
        public Matrix Transform
        {
            get { return transform; }
        }
        public CameraComponent(GameObject parent, float zoom, float rotation)
        {
            parentGameObject = parent;
            Zoom = zoom;
            Rotation = rotation;
        }
        public override void Update(GameTime gameTime)
        {
            TransformComponent parentTransform = GetParent().GetComponent<TransformComponent>();
            Vector2 parentPosition = parentTransform.Position;
            transform =
              Matrix.CreateTranslation(new Vector3(-Position.X - parentPosition.X, -Position.Y - parentPosition.Y, 0)) *
                                         Matrix.CreateRotationZ(Rotation) *
                                         Matrix.CreateScale(new Vector3(Zoom, Zoom, 1)) *
                                         Matrix.CreateTranslation(new Vector3(0, 0, 0));
        }
    }
}
