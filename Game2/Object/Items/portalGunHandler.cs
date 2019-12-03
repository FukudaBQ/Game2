using Game2.Sprites.Enemies;
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
    class PortalGunHandler
    {
        private float timeLastUpdate = 0f;
        private Dir direction = Dir.Down;
        private Vector2 tempPosition;
        public int monsterType;


        public void Update(GameTime gameTime, Player player)
        {
            foreach (PortalGun p in PortalGun.portalGuns)
            {
                int sum = player.Radius + p.Radius;
                if (Vector2.Distance(player.Position, new Vector2(p.Position.X , p.Position.Y )) < sum)
                {
                    p.Collided = true;
                    PortalGun.portalGunStoY.Add(new PortalGun(p.Position, direction));
                    PortalGun.portalGunStoB.Add(new PortalGun(p.Position, direction));



                }

            }
            PortalGun.portalGuns.RemoveAll(p => p.Collided == true);
            foreach (PortalGun proj in PortalGun.yellowBs)
            {
                proj.ProjUpdate(gameTime, player);
                //tempPosition = proj.TempPosition;


            }
            foreach (PortalGun proj in PortalGun.blueBs)
            {
                proj.ProjUpdate(gameTime, player);
                //tempPosition = proj.TempPosition;
                

            }

            if (PortalGun.blueBs.Count > 0)
            {
                //Game1.blackHole3.Able = false;
            }
            if (PortalGun.yellowBs.Count > 0)
            {
                //Game1.blackHole4.Able = false;
            }



        }

        public void Draw(SpriteBatch spriteBatch, Texture2D textureToDraw, List<PortalGun> pokeballToDraw)
        {
            foreach (PortalGun i in pokeballToDraw)
            {
                spriteBatch.Draw(textureToDraw, i.Position, Color.White);
            }
        }
    }
}
