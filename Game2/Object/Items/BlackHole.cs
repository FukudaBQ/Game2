using Microsoft.Xna.Framework;
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

        public Vector2 Position
        {
            get { return position; }
        }
        public BlackHole(Vector2 pos)
        {
            position = pos;
        }
    }
}
