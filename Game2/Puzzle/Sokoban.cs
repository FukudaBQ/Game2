using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Puzzle
{
    /*
     * 荷物
     */
    public class Sokoban
    {
        private Texture2D texture;
        private SpriteBatch spriteBatch;
        private int[] baggageX = {5920, 6000, 6080};
        private int[] baggageY = { 12600, 12600, 12600 };
        private int[] destX = { 5920, 6000, 6080 };
        private int[] destY = {12680, 12680, 12680 };
        private List<Baggage> baggage = new List<Baggage>();
        private List<DestPoint> dest = new List<DestPoint>();
        public Sokoban(Texture2D texture, SpriteBatch spriteBatch)
        {
            this.texture = texture;
            this.spriteBatch = spriteBatch;
            populate();
        }

        private void populate()
        {
            for(int i = 0; i < baggageX.Length; i ++)
            {
                baggage.Add(new Baggage(texture, spriteBatch, baggageX[i], baggageY[i]));
                dest.Add(new DestPoint(texture, spriteBatch, destX[i], destY[i]));
            }
        }

        public void Draw()
        {
            foreach (DestPoint i in dest)
            {
                i.Draw();
            }
            foreach (Baggage i in baggage)
            {
                i.Draw();
            }
        }
        public void Push(Dir direction, Vector2 position)
        {
            switch (direction)
            {
                case Dir.UpSword:

                case Dir.Up:
                    PushUP(direction, position);
                    break;
                case Dir.DownSword:
                case Dir.Down:
                    PushDown(direction, position);
                    break;
                case Dir.LeftSword:
                case Dir.Left:
                    PushRight(direction, position);
                    break;
                case Dir.RightSword:
                case Dir.Right:
                    PushRight(direction, position);
                    break;
                default:
                    break;
            }
        }

        private void PushRight(Dir direction, Vector2 position)
        {
            throw new NotImplementedException();
        }

        private void PushDown(Dir direction, Vector2 position)
        {
            throw new NotImplementedException();
        }

        public void PushUP(Dir direction, Vector2 position)
        {
            Console.Write(position.X + " " + position.Y);
            Baggage i = Detect(direction, position);
            if (i != null)
            {
                i.PushUp();
            }
            Check(i);
        }

        private Baggage Detect(Dir direction, Vector2 position)
        {
            Baggage ans = null;
            switch (direction)
            {
                case Dir.Up:
                    ans = DetectUp(direction, position);
                    break;
                case Dir.Down:
                    //ans = DetectUp(direction, position);
                    break;
                default:
                    ans = null;
                    break;
            }
            return ans;
        }



        private Baggage DetectUp(Dir direction, Vector2 position)
        {
            for (int i = 0; i < baggage.Count; i++)
                {
                    int Dist = baggage.ElementAt(i).GetDistY(direction, position);
                    if ((Dist >= -80) &&
                    (Dist <= 0))
                    {
                        return baggage.ElementAt(i);
                    }
                }
            return null;
        }

        private void Check(Baggage i)
        {
        }
    }

    public class Baggage
    {
        public int a = 9;
        private Texture2D texture;
        private SpriteBatch spriteBatch;
        private int width = 37;
        private int height = 51;
        private int locationX;
        private int locationY;
        private int sourceX = 45;
        private int sourceY = 0;
        private int blockWidth = 80;
        private int blockHeight = 80;
        private int offsetX = 0;
        private int offsetY = 0;
        public Baggage(Texture2D texture, SpriteBatch spriteBatch, int X, int Y)
        {
            this.texture = texture;
            this.spriteBatch = spriteBatch;
            this.locationX = X;
            this.locationY = Y;
        }
        public void Draw()
        {
            Rectangle sourceRectangle = new Rectangle(sourceX, sourceY, width, height);
            Rectangle destinationRectangle = new Rectangle(locationX + 
                offsetX * blockWidth, locationY + offsetY * blockHeight, blockWidth, blockHeight);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void PushUp()
        {
            offsetY--;
        }

        public void PushDown()
        {
            offsetY++;
        }

        public void PushLeft()
        {
            offsetX--;
        }
        public void PushRight()
        {
            offsetX++;
        }

        //baggage - player, baggage downer as positive
        public int GetDistY(Dir direction, Vector2 position)
        {
            int CurrentLoc = locationY + offsetY * blockHeight;
            if ((position.X >= (locationX + offsetX * blockWidth) - 10) &&
                (position.X <= (locationX + offsetX * blockWidth + blockWidth) + 10))
            {
                if (CurrentLoc > position.Y)
                {
                    return CurrentLoc - (int)position.Y;
                }
                else
                {
                    Console.Write(CurrentLoc + blockHeight - (int)position.Y);
                    return  CurrentLoc + blockHeight - (int)position.Y;
                }
            }
            return 1024;
        }
    }

    public class DestPoint
    {
        private Texture2D texture;
        private SpriteBatch spriteBatch;
        private int width = 39;
        private int height = 51;
        private int locationX;
        private int locationY;
        private int sourceX = 0;
        private int sourceY = 0;
        private int blockWidth = 80;
        private int blockHeight = 80;
        public DestPoint(Texture2D texture, SpriteBatch spriteBatch, int X, int Y)
        {
            this.texture = texture;
            this.spriteBatch = spriteBatch;
            this.locationX = X;
            this.locationY = Y;
        }
        public void Draw()
        {
            Rectangle sourceRectangle = new Rectangle(sourceX, sourceY, width, height);
            Rectangle destinationRectangle = new Rectangle(locationX, locationY, blockWidth, blockHeight);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.LightPink);
        }
    }
}
