using Game2.Sprites.Enemies;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Factory
{
    class EnemyFactory
    {
        private Texture2D bat;
        private Texture2D knight;
        private Texture2D hand;
        private int radius;
        private Vector2 hitPos;
        public static EnemyFactory instance = new EnemyFactory();
        public static List<EnemyFactory> enemies = new List<EnemyFactory>();

        public int Radius
        {
            get
            {
                return radius;

            }
        }
        public Vector2 HitsPos
        {
            get
            {
                return hitPos;
            }
        }
        public static EnemyFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private EnemyFactory()
        {
        }
        public static bool collide(Vector2 otherPos, int otherRad)
        {
            foreach (EnemyFactory i in EnemyFactory.enemies)
            {
                int sum = i.Radius + otherRad;
                if (Vector2.Distance(i.hitPos, otherPos) < sum)
                {
                    return true;
                }
            }
            return false;
        }
        public void LoadAllTextures(ContentManager content)
        {
            bat = content.Load<Texture2D>("bat");
            knight = content.Load<Texture2D>("knight");
            //stalfos = content.Load<Texture2D>("stalfos");
            hand = content.Load<Texture2D>("hand");
        }
    }
}
