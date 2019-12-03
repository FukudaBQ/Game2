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
    class Bat
    {
        private Texture2D texture { get; set; }
        private Vector2 location;
        private SpriteBatch spriteBatch { get; set; }
        //private bool hitted=true;
        public Color color = Color.White;
        private int currentFrame;
        Random rnd = new Random();
        private Vector2 temp;
        private int totalFrame;
        private float timeLastUpdate = 0f;
        protected int health=1;
        protected int speed=80;
        protected int radius = 20;
        protected int length = 20;
        protected int width = 10;
        public int rand = 1;
        private float timer = 0;
        public static List<Bat> bats = new List<Bat>();
        public static List<Bat> batF = new List<Bat>();
        public Vector2 Location
        {
            get { return location; }
            set { location = value; }
        }
        public int Health
        {
            get { return health; }
            set { health = value; }
        }
        public int Radius
        {
            get { return radius; }
        }
        public float Timer
        {
            get { return timer; }
            set { timer = value; }
        }
        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        public Bat(Texture2D texture, Vector2 location, SpriteBatch batch)
        {
            this.texture = texture;
            this.location = location;
            spriteBatch = batch;
            currentFrame = 0;
            totalFrame = 2;
        }
        public void Update(GameTime gametime, Vector2 playerPos)
        {
            float dt = (float)gametime.ElapsedGameTime.TotalSeconds;

            timeLastUpdate += dt;

            if (timeLastUpdate > 0.2f)
            {
                currentFrame++;
                if (currentFrame == totalFrame)
                {
                    currentFrame = 0;
                }
                timeLastUpdate = 0f;
            }
            
            Vector2 moveDir = playerPos - location;
            moveDir.Normalize();
            Vector2 tempPos = location;
            tempPos += moveDir * speed * dt;
            if (!Blocks.Blocks.didCollide(tempPos, length, width))
            {
                location += moveDir * speed * dt;
            }
            
            
        }

        public void Update2(GameTime gametime, Vector2 playerPos)
        {
            foreach (Bat b in batF)
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

                foreach (Bat bf in Bat.batF)
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
            

        }
        public void Draw(Vector2 Location)
        {

            Rectangle sourceRectangle = new Rectangle(4+currentFrame*24, 6, 16, 16);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16 * 4, 16 * 4);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color);
        }

        public void Draw2(Vector2 Location)
        {

            Rectangle sourceRectangle = new Rectangle(4 + currentFrame * 24, 6, 16, 16);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16 * 4, 16 * 4);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.Red);
        }
    }
}
