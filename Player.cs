using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading.Tasks;

namespace IdleClicker.Source
{
    public class Player
    {
        public int intBits;
        public double doubleBits;
        public int bitsPerSecond;
        public int bitsPerClick;
        public Game1 game;

        //parallel arrays link a certain image
        //with the amount of bits we have
        public int[] bitsThreshold;
        public Texture2D[] bitsImage;
        public Texture2D clicker;
        public Texture2D stopwatch;

        public Player(Game1 _game)
        {
            intBits = 0;
            doubleBits = 1100;
            bitsPerSecond = 0;
            bitsPerClick = 1;
            game = _game;

            bitsThreshold = new int[] { 1, 100, 1000, 5000, 10000, 100000 };
            bitsImage = new Texture2D[]
            {
                game.bits1,
                game.bits100,
                game.bits1000,
                game.bits5000,
                game.bits10000,
                game.bits100000
            };
            clicker = game.clicker;
            stopwatch = game.stopwatch;

        }

        public virtual void update(GameTime gameTime)
        {
            doubleBits += (double)bitsPerSecond / 60;
            intBits = (int)doubleBits;
        }

        public virtual void draw(SpriteBatch spriteBatch)
        {
            int imageSelect = 0;
            for(int i = 1; i < bitsThreshold.Length; i++)
            {
                if(doubleBits >= bitsThreshold[i])
                {
                    imageSelect = i;
                }
            }
            spriteBatch.Draw(bitsImage[imageSelect], new Rectangle(0, 0, 80, 80), Color.White);
            spriteBatch.DrawString(game.InfoFont48, intBits.ToString(), new Vector2(85, 0), Color.Black);

            spriteBatch.Draw(stopwatch, new Rectangle(0, 80, 80, 80), Color.White);
            spriteBatch.DrawString(game.InfoFont48, bitsPerSecond.ToString(), new Vector2(85, 80), Color.Black);

            spriteBatch.Draw(clicker, new Rectangle(0, 160, 80, 80), Color.White);
            spriteBatch.DrawString(game.InfoFont48, bitsPerClick.ToString(), new Vector2(85, 160), Color.Black);
        }
    }
}
