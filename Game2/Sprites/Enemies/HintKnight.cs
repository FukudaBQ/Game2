using Game2.Object.Items;
using Game2.Sprites.Link;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Sprites.Enemies
{
    class HintKnight
    {
        private Texture2D texture { get; set; }
        private Vector2 location;
        private SpriteBatch spriteBatch { get; set; }
        private int currentFrame;
        private int totalFrame;
        private float timeLastUpdate = 0f;
        public Color color = Color.Red;
        public static List<HintKnight> hintKnights = new List<HintKnight>();
        public Vector2 Location
        {
            get { return location; }
            set { location = value; }
        }
        public HintKnight(Texture2D texture, Vector2 location, SpriteBatch batch)
        {
            this.texture = texture;
            this.location = location;
            spriteBatch = batch;
            currentFrame = 0;
            totalFrame = 2;
        }
        public void Update(GameTime gametime)
        {
            timeLastUpdate += (float)gametime.ElapsedGameTime.TotalSeconds;

            if (timeLastUpdate > 0.2f)
            {
                currentFrame++;
                if (currentFrame == totalFrame)
                {
                    currentFrame = 0;
                }
                timeLastUpdate = 0f;
            }

        }
        public void Draw()
        {

            Rectangle sourceRectangle = new Rectangle(0, 0 + currentFrame * 30, 18, 18);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16 * 4, 16 * 4);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color);
        }
    }
}
