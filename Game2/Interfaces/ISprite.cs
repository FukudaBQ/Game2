using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Interfaces
{
    public interface ISprite
    {
        void Update(GameTime gameTime);
        void Draw();
    }
}
