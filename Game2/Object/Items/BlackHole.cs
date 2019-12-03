using Game2.Sprites.Link;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Object.Items
{
    public class BlackHole
    {
        private Vector2 position;
        private bool collided;
        private int radius=15;
        private Shining sprite;
        private bool able=true;

        public bool Able
        {
            get { return able; }
            set { able = value; }
        }
        
        

        public BlackHole(Vector2 pos,Texture2D texture)
        {
            position = pos;
            collided = false;
            sprite = new Shining(texture, 1, 1, 207, 186, 0);

        }

        public bool Collided
        {
            get { return collided; }
            set { collided = value; }
        }

        public Vector2 Position
        {
            get { return position; }
        }
        public BlackHole(Vector2 pos)
        {
            position = pos;
        }
        public void Update(GameTime gameTime,Player player,BlackHole dest)
        {    
            int sum = radius+ player.Radius;
            if (Vector2.Distance(position, player.Position) < sum&& player.HealthTimer <= 0)
            {
             collided = true;
             player.setX(dest.Position.X+30);
             player.setY(dest.Position.Y+30);
             player.HealthTimer = 1.5f;
            }
        
        }

        public Vector2 Update(GameTime gameTime, Player player, int command, Vector2 camPos)
        {
            int sum = radius + player.Radius;
            if (Vector2.Distance(position, player.Position) < sum && player.HealthTimer <= 0)
            {
                collided = true;
                player.HealthTimer = 1.5f;
                if (command == 1)
                {
                    player.setX(2980);
                    player.setY(12800);
                    return new Vector2(3200, 12520);
                }
                else
                {
                    player.setX(5700);
                    player.setY(12800);
                    return new Vector2(5760, 12520);
                }
            }
            return camPos;
            
        }
        public int Radius
        {
            get { return radius; }

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            this.sprite.Draw(spriteBatch, position);
        }
    }
}
