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
        Random rnd = new Random();
        private SpriteBatch spriteBatch { get; set; }
        private int currentFrame;
        private int totalFrame;
        protected int health = 1;
        private float timeLastUpdate = 0f;
        private float timer = 0;
        public Color color = Color.Red;
        protected int radius = 20;
        public static List<HintKnight> hintKnights = new List<HintKnight>();
        public float Timer
        {
            get { return timer; }
            set { timer = value; }
        }
        public int Radius
        {
            get { return radius; }
        }
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
        public void Update(GameTime gametime, Player player)
        {
            //float dt = (float)gametime.ElapsedGameTime.TotalSeconds;
            
            foreach (Item bu in Item.items)
            {
                int sum = player.Radius + bu.Radius;
                if (Vector2.Distance(player.Position, bu.Position) < sum)
                {
                    color = Color.Blue;
                    if (color == Color.Red)
                    {
                        color = Color.Blue;
                    }else if (color == Color.Blue)
                    {
                        color = Color.Green;
                    }
                    else if (color == Color.Green)
                    {
                        color = Color.Yellow;
                    }

                }
            }
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
