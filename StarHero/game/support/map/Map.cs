using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StarHero.game.support;
using System;
namespace StarHero.game.support
{
    class Map : GameComponent
    {
        //地图宽度
        float width;
        public float Width { get { return width; } }
        //地图高度
        float height;
        public float Height { get { return height; } }
        //纵向地块数量
        int heightBlockNum;
        //横向地块数量
        int widthBlockNum;
        //屏幕高度
        float halfScreenHeight;
        //屏幕宽度
        float halfScreenWidth;
        //地块数组
        TopographyBlock[,] blockArray;

        public Map(String mapFilePath, float screenWidth, float screenHeight, GraphicsDevice graphicsDevice)
        {
            halfScreenHeight = screenHeight / 2;
            halfScreenWidth = screenWidth / 2;
            //初始化地图数据
            string text = System.IO.File.ReadAllText(mapFilePath);
            JObject mapJson = (JObject)JsonConvert.DeserializeObject(text);
            //地块数量
            heightBlockNum = (int)mapJson["heightBlockNum"];
            widthBlockNum = (int)mapJson["widthBlockNum"];
            //地图宽高
            width = widthBlockNum * TopographyBlock.width;
            height = heightBlockNum * TopographyBlock.height;
            //读取地块
            blockArray = new TopographyBlock[widthBlockNum, 10];
            JArray mapData = JArray.Parse(mapJson["mapData"].ToString());
            for(int i = 0; i < widthBlockNum; i++)
            {
                JArray rowData = JArray.Parse(mapData[i].ToString());
                for(int j = 0; j < heightBlockNum; j++)
                {
                    blockArray[i, j] = initBlock(JObject.Parse(rowData[j].ToString()), graphicsDevice);
                }
            }
        }
        //根据文件内容生成地块
        TopographyBlock initBlock(JObject jObject, GraphicsDevice graphicsDevice)
        {
            return new Land(graphicsDevice, (String)jObject["areaName"]);
        }
        //渲染地图
        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            //计算要渲染的地块下标
            int startRow = Math.Max((int)((position.Y - halfScreenHeight) / TopographyBlock.width) - 1, 0);
            int endRow = Math.Min((int)((position.Y + halfScreenHeight) / TopographyBlock.width) + 1, widthBlockNum);
            int startColumn = Math.Max((int)((position.X - halfScreenWidth) / TopographyBlock.height) - 1, 0);
            int endColumn = Math.Min((int)((position.X + halfScreenWidth) / TopographyBlock.height) + 1, heightBlockNum);
            //地块初始位置
            Vector2 topLeftOfSprite = Vector2.Zero;
            Vector2 origin = new Vector2(1,1);
            Vector2 scaleVec = new Vector2(1, 1);
            for (int i = startRow; i < endRow;i++)
            {
                topLeftOfSprite.Y = TopographyBlock.height * i;
                for (int j = startColumn; j < endColumn; j++)
                {
                    topLeftOfSprite.X = TopographyBlock.width * j;
                    blockArray[i, j].Draw(spriteBatch, topLeftOfSprite, Color.White);
                }
            }
        }
        //重置屏幕大小
        public void setScreenSize(float width, float height)
        {
            this.halfScreenWidth = width / 2;
            this.halfScreenHeight = height / 2;
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
