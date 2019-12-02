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
    class PokeballHandler
    {
        private float timeLastUpdate = 0f;
        private Dir direction = Dir.Down;
        private Vector2 tempPosition;
        public int monsterType;


        public void Update(GameTime gameTime, Player player)
        {
            //float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            timeLastUpdate += (float)gameTime.ElapsedGameTime.TotalSeconds;
            foreach (Pokeball proj in Pokeball.pokeballProj)
            {
                proj.ProjUpdate(gameTime, player);
                tempPosition = proj.TempPosition;

            }
            if(Pokeball.pokeballProj.RemoveAll(p => p.Speed == 0)==1)
            {
                Pokeball.pokeballs.Add(new Pokeball(tempPosition, direction));
            }
            foreach (Pokeball proj in Pokeball.pokeballwithMonsterProj)
            {
                proj.ProjUpdateM(gameTime, player);
                tempPosition = proj.TempPosition;
                proj.Monster = monsterType;

            }
            
            //if (Pokeball.pokeballs.Count == 0 && Pokeball.pokeballProj.Count == 0 && Pokeball.pokeballSto.Count == 0)
            
            foreach (Pokeball p in Pokeball.pokeballs)
            {
                int sum = player.Radius + p.Radius;
                if (Vector2.Distance(player.Position, new Vector2(p.Position.X - 15f, p.Position.Y - 15f)) < sum)
                {
                    p.Collided = true;
                    Pokeball.pokeballSto.Add(new Pokeball(p.Position, direction ));


                }

            }
            foreach (Pokeball p in Pokeball.pokeballwithMonster)
            {
                int sum = player.Radius + p.Radius;
                if (Vector2.Distance(player.Position, new Vector2(p.Position.X - 15f, p.Position.Y - 15f)) < sum)
                {
                    p.Collided = true;
                    Pokeball.pokeballwithMonsterSto.Add(new Pokeball(p.Position, direction));


                }

            }
            Pokeball.pokeballs.RemoveAll(p => p.Collided==true);
            Pokeball.pokeballwithMonster.RemoveAll(p => p.Collided == true);
            foreach (Pokeball b in Pokeball.pokeballProj)
            {
                foreach (Bat bat in Bat.bats)
                {
                    int sum = b.Radius + bat.Radius;
                    if (Vector2.Distance(b.Position, bat.Location) < sum)
                    {
                        b.Collided = true;
                        monsterType = 1;
                        tempPosition = b.Position;
                        bat.Health--;
                        if (bat.Health <= 0)
                        {
                            light.lig.Add(new light(new Vector2(bat.Location.X-70f, bat.Location.Y - 75f)));
                            Pokeball.pokeballSto.RemoveAll(p => p.Radius == 10);

                        }
                    }
                }

                foreach (Knight bat in Knight.knights)
                {
                    int sum = b.Radius + bat.Radius;
                    if (Vector2.Distance(b.Position, bat.Location) < sum)
                    {
                        b.Collided = true;
                        monsterType = 2;
                        tempPosition = b.Position;
                        bat.Health--;
                        if (bat.Health <= 0)
                        {
                            light.lig.Add(new light(new Vector2(bat.Location.X - 60f, bat.Location.Y - 65f)));
                            Pokeball.pokeballSto.RemoveAll(p => p.Radius == 10);

                        }
                    }
                }


            }
            if (Pokeball.pokeballProj.RemoveAll(p => p.Collided == true) == 1)
            {
                Pokeball.pokeballwithMonster.Add(new Pokeball(tempPosition, direction));
                foreach (Pokeball b in Pokeball.pokeballwithMonster)
                {
                    b.Monster = monsterType;
                }
            }


        }

        public void Draw(SpriteBatch spriteBatch, Texture2D textureToDraw, List<Pokeball> pokeballToDraw)
        {
            foreach (Pokeball i in pokeballToDraw)
            {
                spriteBatch.Draw(textureToDraw, i.Position, Color.White);
            }
        }
    }
}
