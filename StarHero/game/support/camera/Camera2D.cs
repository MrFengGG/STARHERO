using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace StarHero.game.support
{
    class Camera2D : GameObject
    {
        //摄像头在X轴最大边界
        float maxX;
        //摄像头在X轴最小边界
        float minX;
        //摄像头在Y轴最大边界
        float maxY;
        //摄像头在Y轴最小边界
        float minY;
        //缩放
        float zoom;
        //旋转角度
        float rotation;
        //变换矩阵
        Matrix transform;
        //摄像头位置
        Vector2 position;
        //更新摄像头位置
        public void SetPosition(Vector2 position)
        {
            if(position.X > minX && position.X < maxX)
            {
                this.position.X = position.X;
            }
            if (position.Y > minY && position.Y < maxY)
            {
                this.position.Y = position.Y;
            }
        }
        public Vector2 getPosition()
        {
            return position;
        }
        //更新屏幕和地图大小
        public void SetScreenSize(float mapWidth, float mapHeight, float screenWidth, float screenHeight)
        {
            this.minX = screenWidth / 2;
            this.maxX = mapWidth - minX;

            this.minY = screenHeight / 2;
            this.maxY = mapHeight - minY;
        }
        //更新缩放
        public float Zoom { get { return zoom; } set { zoom = Math.Max(value, 0.1f); } }
        //获取变换矩阵
        public Matrix Transform{
            get { return transform; }
        }
        public Matrix GetTransformation(GraphicsDevice graphicsDevice)
        {
            transform = 
              Matrix.CreateTranslation(new Vector3(- position.X, -position.Y, 0)) *
                                         Matrix.CreateRotationZ(rotation) *
                                         Matrix.CreateScale(new Vector3(zoom, zoom, 1)) *
                                         Matrix.CreateTranslation(new Vector3(minX, minY, 0));
            return transform;
        }

        public override void Destory()
        {
            throw new NotImplementedException();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public override bool IsActive()
        {
            throw new NotImplementedException();
        }

        public override void SetActive(bool active)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public override void OnCollide(GameObject other)
        {
            throw new NotImplementedException();
        }

        public override bool ContainsTag(string tag)
        {
            throw new NotImplementedException();
        }

        public override HashSet<string> GetAllTags()
        {
            throw new NotImplementedException();
        }

        public override float CanUpdateTargetX(float x)
        {
            throw new NotImplementedException();
        }

        public override float CanUpdateTargetY(float y)
        {
            throw new NotImplementedException();
        }

        public override float CanUpdateTargetRotation(float rotation)
        {
            throw new NotImplementedException();
        }

        public override bool CanUpdateScale(Vector2 scale)
        {
            throw new NotImplementedException();
        }

        public Camera2D(float mapWidth, float mapHeight, float screenWidth, float screenHeight)
        {
            SetScreenSize(mapWidth, mapHeight, screenWidth, screenHeight);
            zoom = 1.0f;
            rotation = 0.0f;
            position = new Vector2(minX, minY);
        }
    }
}
