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
        private int[] destX = { 5950, 6030, 6110 };
        private int[] destY = {12710, 12710, 12710 };
        private List<Baggage> baggage = new List<Baggage>();
        private List<DestPoint> dest = new List<DestPoint>();
        private List<bool> arrived = new List<bool>();
        private int blockWidth = 80;
        private int blockHeight = 80;
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
                baggage.Add(new Baggage(texture, spriteBatch, baggageX[i], baggageY[i], 12360, 12920, 5340, 6220));
                dest.Add(new DestPoint(texture, spriteBatch, destX[i], destY[i]));
                arrived.Add(false);
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
                    PushLeft(direction, position);
                    break;
                case Dir.RightSword:
                case Dir.Right:
                    PushRight(direction, position);
                    break;
                default:
                    break;
            }
        }

        private void PushLeft(Dir direction, Vector2 position)
        {
            Baggage i = Detect(direction, position);
            if (i != null)
            {
                i.PushLeft();
                Check(i);
            }
        }

        private void PushRight(Dir direction, Vector2 position)
        {
            Baggage i = Detect(direction, position);
            if (i != null)
            {
                i.PushRight();
                Check(i);
            }
        }

        private void PushDown(Dir direction, Vector2 position)
        {
            Baggage i = Detect(direction, position);
            if (i != null)
            {
                i.PushDown();
                Check(i);
            }
        }

        public void PushUP(Dir direction, Vector2 position)
        {
            Baggage i = Detect(direction, position);
            if (i != null)
            {
                i.PushUp();
                Check(i);
            }
        }

        private Baggage Detect(Dir direction, Vector2 position)
        {
            Baggage ans;
            switch (direction)
            {
                case Dir.Up:
                    ans = DetectUp(direction, position);
                    break;
                case Dir.Down:
                    ans = DetectDown(direction, position);
                    break;
                case Dir.Left:
                    ans = DetectLeft(direction, position);
                    break;
                case Dir.Right:
                    ans = DetectRight(direction, position);
                    break;
                default:
                    ans = null;
                    break;
            }
            return ans;
        }

        private Baggage DetectRight(Dir direction, Vector2 position)
        {
            for (int i = 0; i < baggage.Count; i++)
            {
                int Dist = baggage.ElementAt(i).GetDistX(direction, position);
                if ((Dist <= 80) &&
                (Dist >= 0))
                {
                    return baggage.ElementAt(i);
                }
            }
            return null;
        }

        private Baggage DetectLeft(Dir direction, Vector2 position)
        {
            for (int i = 0; i < baggage.Count; i++)
            {
                int Dist = baggage.ElementAt(i).GetDistX(direction, position);
                if ((Dist >= -80) &&
                (Dist <= 0))
                {
                    return baggage.ElementAt(i);
                }
            }
            return null;
        }

        private Baggage DetectDown(Dir direction, Vector2 position)
        {
            for (int i = 0; i < baggage.Count; i++)
            {
                int Dist = baggage.ElementAt(i).GetDistY(direction, position);
                if ((Dist <= 80) &&
                (Dist >= 0))
                {
                    return baggage.ElementAt(i);
                }
            }
            return null;
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

        //TODO On going
        private void Check(Baggage i)
        {
            bool IfNotArrived = true;
            for (int j = 0; j < dest.Count; j++)
            {
                if (CheckArrive(i, dest.ElementAt(j)))
                {
                    i.InformArrived();
                    IfNotArrived = false;
                }
            }
            if (IfNotArrived)
            {
                i.InformNotArrived();
            }
        }

        private bool CheckArrive(Baggage baggage, DestPoint destPoint)
        {
            int BaggageX = baggage.GetLocX();
            int BaggageY = baggage.GetLocY();
            int DestPointX = destPoint.getLocX();
            int DestPointY = destPoint.getLocY();
            if ((DestPointX >= BaggageX) && (DestPointX <= (BaggageX + blockWidth)) 
                && (DestPointY >= BaggageY) && (DestPointY <= (BaggageY + blockHeight)))
            {
                return true;
            }
            return false;
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
        private int upLimit;
        private int downLimit;
        private int leftLimit;
        private int rightLimit;
        public Baggage(Texture2D texture, SpriteBatch spriteBatch, int X, int Y, int upLimit, int downLimit, int leftLimit, int rightLimit)
        {
            this.texture = texture;
            this.spriteBatch = spriteBatch;
            this.locationX = X;
            this.locationY = Y;
            this.upLimit = upLimit;
            this.downLimit = downLimit;
            this.leftLimit = leftLimit;
            this.rightLimit = rightLimit;
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
            int Command = 0;
            if (Precheck(Command))
            {
                offsetY--;
            } 
        }

        public void PushDown()
        {
            int Command = 1;
            if (Precheck(Command))
            { 
                offsetY++;
            }
        }

        public void PushLeft()
        {
            int Command = 2;
            if (Precheck(Command))
            {
                offsetX--;
            }
        }
        public void PushRight()
        {
            int Command = 3;
            if (Precheck(Command))
            {
                offsetX++;
            }
        }

        private bool Precheck(int command)
        {
            int CurrentX = locationX + offsetX * blockWidth;
            int CurrentY = locationY + offsetY * blockHeight;
            if ((command < 2)&&(CurrentY > upLimit) && ((CurrentY + blockHeight) < downLimit))
            {
                return true;
            }
            if ((command >= 2) && (CurrentX > leftLimit) && ((CurrentX + blockWidth) < rightLimit))
            {
                return true;
            }/*
            if ((CurrentX > leftLimit) && ((CurrentX + blockWidth) < rightLimit) && 
                (CurrentY > upLimit) && ((CurrentY + blockHeight) < downLimit))
            {
                return true;
            }*/
            return false;
        }

        //baggage - player, baggage downer as positive
        public int GetDistY(Dir direction, Vector2 position)
        {
            int CurrentLoc = locationY + offsetY * blockHeight;
            if ((position.X >= (locationX + offsetX * blockWidth) - 5) &&
                (position.X <= (locationX + offsetX * blockWidth + blockWidth) + 5))
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
        public int GetDistX(Dir direction, Vector2 position)
        {
            int CurrentLoc = locationX + offsetX * blockHeight;
            if ((position.Y >= (locationY + offsetY * blockWidth) - 5) &&
                (position.Y <= (locationY + offsetY * blockWidth + blockWidth) + 5))
            {
                if (CurrentLoc > position.X)
                {
                    return CurrentLoc - (int)position.X;
                }
                else
                {
                    Console.Write(CurrentLoc + blockHeight - (int)position.X);
                    return CurrentLoc + blockHeight - (int)position.X;
                }
            }
            return 1024;
        }

        public void InformArrived()
        {
            sourceX = 89;
        }

        public int GetLocX()
        {
            return locationX + offsetX * blockWidth;
        }

        internal int GetLocY()
        {
            return locationY + offsetY * blockHeight;
        }

        internal void InformNotArrived()
        {
            sourceX = 45;
        }
    }

    public class DestPoint
    {
        private Texture2D texture;
        private SpriteBatch spriteBatch;
        private int width = 13;
        private int height = 18;
        private int locationX;
        private int locationY;
        private int sourceX = 14;
        private int sourceY = 18;
        private int blockWidth = 20;
        private int blockHeight = 20;
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

        internal int getLocX()
        {
            return locationX;
        }

        internal int getLocY()
        {
            return locationY;
        }
    }
}
