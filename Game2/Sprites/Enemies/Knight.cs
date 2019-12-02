using Game2.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Sprites.Enemies
{
    class Knight
    {
        private Texture2D texture { get; set; }
        private Vector2 location;
        Random rnd = new Random();
        private SpriteBatch spriteBatch { get; set; }
        private int currentFrame;
        private int totalFrame;
        public int rand=1;
        private Vector2 temp;
        protected int health = 1;
        private float timeLastUpdate = 0f;
        private float timer = 0;
        protected int speed = 100;
        public Color color = Color.White;
        protected int radius = 20;
        public static List<Knight> knights = new List<Knight>();
        public static List<Knight> knightF = new List<Knight>();
        //aa
        public int Health
        {
            get { return health; }
            set { health = value; }
        }
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
        public Knight(Texture2D texture, Vector2 location, SpriteBatch batch)
        {
            this.texture = texture;
            this.location = location;
            spriteBatch = batch;
            currentFrame = 0;
            totalFrame = 2;
        }
        public void Update(GameTime gametime)
        {
            float dt = (float)gametime.ElapsedGameTime.TotalSeconds;
            if (timer > 0)
            {
                timer -= dt;
            }
            if (timer <= 0)
            {
                rand = rnd.Next(1, 5);
                timer = 1.5f;
            }
            switch (rand)
            {
                case 1:
                    temp = location;
                     temp.X= location.X + speed * dt;
                    if (!Blocks.Blocks.didCollide(temp, 20, 10))
                    {
                        location.X += speed * dt;
                    }
                    else
                    {
                        rand = rnd.Next(1, 5);
                    }
                    break;
                case 2:
                    temp = location;
                    temp.X = location.X - speed * dt;
                    if (!Blocks.Blocks.didCollide(temp, 20, 10))
                    {
                        location.X -= speed * dt;
                    }
                    else
                    {
                        rand = rnd.Next(1, 5);
                    }
                    break;
                case 3:
                    temp = location;
                    temp.Y = location.Y + speed * dt;
                    if (!Blocks.Blocks.didCollide(temp, 20, 10))
                    {
                        location.Y += speed * dt;
                    }
                    else
                    {
                        rand = rnd.Next(1, 5);
                    }
                    break;
                case 4:
                    temp = location;
                    temp.Y = location.Y - speed * dt;
                    if (!Blocks.Blocks.didCollide(temp, 20, 10))
                    {
                        location.Y -= speed * dt;
                    }
                    else
                    {
                        rand = rnd.Next(1, 5);
                    }
                    break;
                default:
                    break;

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

        public void Update2(GameTime gametime)
        {
            float dt = (float)gametime.ElapsedGameTime.TotalSeconds;
            if (timer > 0)
            {
                timer -= dt;
            }
            if (timer <= 0)
            {
                rand = rnd.Next(1, 5);
                timer = 1.5f;
            }
            switch (rand)
            {
                case 1:
                    temp = location;
                    temp.X = location.X + speed * dt;
                    if (!Blocks.Blocks.didCollide(temp, 20, 10))
                    {
                        location.X += speed * dt;
                    }
                    else
                    {
                        rand = rnd.Next(1, 5);
                    }
                    break;
                case 2:
                    temp = location;
                    temp.X = location.X - speed * dt;
                    if (!Blocks.Blocks.didCollide(temp, 20, 10))
                    {
                        location.X -= speed * dt;
                    }
                    else
                    {
                        rand = rnd.Next(1, 5);
                    }
                    break;
                case 3:
                    temp = location;
                    temp.Y = location.Y + speed * dt;
                    if (!Blocks.Blocks.didCollide(temp, 20, 10))
                    {
                        location.Y += speed * dt;
                    }
                    else
                    {
                        rand = rnd.Next(1, 5);
                    }
                    break;
                case 4:
                    temp = location;
                    temp.Y = location.Y - speed * dt;
                    if (!Blocks.Blocks.didCollide(temp, 20, 10))
                    {
                        location.Y -= speed * dt;
                    }
                    else
                    {
                        rand = rnd.Next(1, 5);
                    }
                    break;
                default:
                    break;

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

            foreach (Knight bf in Knight.knightF)
            {
                speed = 100;
                foreach (Bat bat in Bat.bats)
                {
                    int sum = bf.Radius + bat.Radius;
                    if (Vector2.Distance(bf.Location, bat.Location) < sum)
                    {
                        bat.Health--;
                        if (bat.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(bat.Location));

                        }
                    }
                }

                foreach (Knight kn in Knight.knights)
                {
                    int sum = bf.Radius + kn.Radius;
                    if (Vector2.Distance(bf.Location, kn.Location) < sum)
                    {
                        kn.Health--;
                        if (kn.Health <= 0)
                        {
                            explosion.exp.Add(new explosion(kn.Location));
                        }
                    }

                }
                foreach (Dragon dra in Dragon.dragons)
                {
                    int sum = bf.Radius + dra.Radius;
                    if (Vector2.Distance(bf.Location, dra.Location) < sum)
                    {
                        
                        explosion.exp.Add(new explosion(bf.Location));
                        bf.Health--;
                    }
                }


            }
            

        }
        public void Draw()
        {
            
            Rectangle sourceRectangle = new Rectangle(0, 0 + currentFrame * 30, 18, 18);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16 * 4, 16 * 4);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color);
        }
        public void Draw2()
        {

            Rectangle sourceRectangle = new Rectangle(0, 0 + currentFrame * 30, 18, 18);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16 * 4, 16 * 4);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.Blue);
        }
    }
}
