using Game2.Collision;
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
    class BlackHole
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
            if (CollisionHandler.rm == 3)
            {
                Game1.tempBlackHole1Position = new Vector2(player.Position.X - 100, player.Position.Y - 100);
                Game1.tempBlackHole2Position = new Vector2(player.Position.X + 100, player.Position.Y - 200);
            }
        
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
