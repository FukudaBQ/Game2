﻿using Game2.Sprites.Link;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUDManager
{
    public class HUD
    {
        private Player player;
        private Texture2D texture;
        private Texture2D mapTexture;
        private SpriteBatch batch;
        private List<HUDHeart> heart;
        private HUDMap map;
        private Texture2D green;
        private HUDWord[] wordKey;
        private int[] keyNumX = { 3060, 3085, 3110 };
        private int keyNumY = 12080;
        private int coinNumY = 12000;
        private int bombNumY = 12160;
        private HUDWord[] wordCoins;
        private HUDWord[] wordBomb;
        private HUDSword sword;
        private HUDArrow arrow;

        public HUD(Player player, Texture2D texture, SpriteBatch batch, Texture2D mapTexture, Texture2D veryGreen)
        {
            this.player = player;
            this.texture = texture;
            this.mapTexture = mapTexture;
            this.batch = batch;
            this.green = veryGreen;
            heart = new List<HUDHeart>();
            RegisterHeart();
            map = new HUDMap();
            wordKey = new HUDWord[3];
            RegisterKey();
            wordCoins = new HUDWord[3];
            RegisterCoins();
            wordBomb = new HUDWord[3];
            RegisterBomb();
            sword = new HUDSword();
            arrow = new HUDArrow();
        }
        private void RegisterHeart()
        {
            heart.Add(new HUDHeart(3480, 12080));
            heart.Add(new HUDHeart(3560, 12080));
            heart.Add(new HUDHeart(3640, 12080));
        }

        private void RegisterBomb()
        {
            wordBomb[0] = new HUDWord(keyNumX[0], bombNumY, 10);
            wordBomb[1] = new HUDWord(keyNumX[1], bombNumY, 0);
            wordBomb[2] = new HUDWord(keyNumX[2], bombNumY, 5);
        }
        public void LostHeart()
        {
            heart.RemoveAt(heart.Count - 1);
        }

        private void RegisterCoins()
        {
            wordCoins[0] = new HUDWord(keyNumX[0], coinNumY, 10);
            wordCoins[1] = new HUDWord(keyNumX[1], coinNumY, 0);
            wordCoins[2] = new HUDWord(keyNumX[2], coinNumY, 0);
        }

        private void RegisterKey()
        {
            wordKey[0] = new HUDWord(keyNumX[0], keyNumY, 10);
            wordKey[1] = new HUDWord(keyNumX[1], keyNumY, 0);
            wordKey[2] = new HUDWord(keyNumX[2], keyNumY, 0);
        }

        public void BombNumUpdate(int numOfBombs)
        {
            int tenth = numOfBombs / 10;
            int num = numOfBombs % 10;
            wordBomb[1] = new HUDWord(keyNumX[1] + wordBomb[1].getX() * 1280, bombNumY + wordBomb[1].getY() * 2040, tenth);
            wordBomb[2] = new HUDWord(keyNumX[2] + wordBomb[2].getX() * 1280, bombNumY + wordBomb[2].getY() * 2040, num);
        }

        public void KeyNumUpdate(int numOfKeys)
        {
            int tenth = numOfKeys / 10;
            int num = numOfKeys % 10;
            wordKey[1] = new HUDWord(keyNumX[1] + wordKey[1].getX() * 1280, keyNumY +wordKey[1].getY() * 2040, tenth);
            wordKey[2] = new HUDWord(keyNumX[2] + wordKey[2].getX() * 1280, keyNumY + wordKey[2].getY() * 2040, num);
        }

        public void HeartUP()
        {
            foreach (HUDHeart i in heart)
            {
                i.moveUp();
            }
        }

        public void HeartDown()
        {

            foreach (HUDHeart i in heart)
            {
                i.moveDown();
            }
        }

        public void HeartLeft()
        {
            foreach (HUDHeart i in heart)
            {
                i.moveLeft();
            }
        }

        public void HeartRight()
        {
            foreach (HUDHeart i in heart)
            {
                i.moveRight();
            }
        }

        public void KeyNumUp()
        {
            foreach (HUDWord i in wordKey)
            {
                i.moveUp();
            }
            foreach (HUDWord i in wordCoins)
            {
                i.moveUp();
            }
            foreach (HUDWord i in wordBomb)
            {
                i.moveUp();
            }
        }

        public void KeyNumDown()
        {
            foreach (HUDWord i in wordKey)
            {
                i.moveDown();
            }
            foreach (HUDWord i in wordCoins)
            {
                i.moveDown();
            }
            foreach (HUDWord i in wordBomb)
            {
                i.moveDown();
            }
        }
        public void KeyNumLeft()
        {
            foreach (HUDWord i in wordKey)
            {
                i.moveLeft();
            }
            foreach (HUDWord i in wordCoins)
            {
                i.moveLeft();
            }
            foreach (HUDWord i in wordBomb)
            {
                i.moveLeft();
            }
        }
        public void KeyNumRight()
        {
            foreach (HUDWord i in wordKey)
            {
                i.moveRight();
            }
            foreach (HUDWord i in wordCoins)
            {
                i.moveRight();
            }
            foreach (HUDWord i in wordBomb)
            {
                i.moveRight();
            }
        }

        public void updateHeartLoc(int X, int Y)
        {
            foreach (HUDHeart i in heart)
            {
                i.UpdateLoc(X, Y);
            }
        }
        public void updateMapLoc(int X, int Y)
        {
            map.UpdateLoc(X, Y);
        }
        public int getMapDestX()
        {
            return map.getX();
        }
        public int getMapDestY()
        {
            return map.getY();
        }

        public void indexUp()
        {
            map.moveUp();
        }

        public void indexDown()
        {
            map.moveDown();
        }
        public void indexLeft()
        {
            map.moveLeft();
        }
        public void indexRight()
        {
            map.moveRight();
        }

        public void SwordUp()
        {
            sword.moveUp();
        }

        public void SwordDown()
        {
            sword.moveDown();
        }
        public void SwordLeft()
        {
            sword.moveLeft();
        }
        public void SwordRight()
        {
            sword.moveRight();
        }


        public void ArrowUp()
        {
            arrow.moveUp();
        }

        public void ArrowDown()
        {
            arrow.moveDown();
        }
        public void ArrowLeft()
        {
            arrow.moveLeft();
        }
        public void ArrowRight()
        {
            arrow.moveRight();
        }

        public void Draw()
        {
            foreach (HUDHeart i in heart)
            {
                i.Draw(texture, batch);
            }
            map.Draw(mapTexture, batch, green);
            foreach (HUDWord i in wordKey)
            {
                i.Draw(texture, batch);
            }
            foreach (HUDWord i in wordCoins)
            {
                i.Draw(texture, batch);
            }
            foreach (HUDWord i in wordBomb)
            {
                i.Draw(texture, batch);
            }
            sword.Draw(texture, batch);
            arrow.Draw(texture, batch);
        }
        public int getHeartDestX()
        {
            return 0;
        }
        public int getHeartDestY()
        {
            return 0;
        }

    }
}