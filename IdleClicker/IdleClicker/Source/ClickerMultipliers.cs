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
    public class ClickerMultipliers : Upgrades
    {
        public int[] cost;
        public Texture2D[] images;
        public bool[] availability;
        public int currentIndex;
        public int maxIndex;

        public ClickerMultipliers(Game1 _game, Rectangle _rectangle)
            : base(_game, _rectangle)
        {
            cost = new int[]{
                100,
                1000
            };

            images = new Texture2D[]{
                game.tier2Sub,
                game.tier3Sub
            };

            availability = new bool[]{
                true,
                true
            };

            currentIndex = 0;
            maxIndex = cost.Length - 1;
        }

        public override void update(GameTime gameTime)
        {
            if(game.position.X > rectangle.X &&
                game.position.X < rectangle.X + rectangle.Width &&
                game.position.Y > rectangle.Y &&
                game.position.Y < rectangle.Y + rectangle.Height)
            {
                if(game.mouseState.LeftButton == ButtonState.Pressed && game.lastMouseState == false)
                {
                    if(game.player.doubleBits >= cost[currentIndex] && availability[currentIndex] == true)
                    {
                        game.player.doubleBits -= cost[currentIndex];
                        game.player.bitsPerClick *= 2;
                        availability[currentIndex] = false;
                        currentIndex++;
                        if(currentIndex > maxIndex)
                        {
                            currentIndex = maxIndex;
                        }
                    }
                }
            }
        }

        public override void draw(SpriteBatch spriteBatch)
        {
            if (availability[currentIndex] == true)
            {
                spriteBatch.Draw(images[currentIndex], rectangle, Color.White);
            }
            else
            {
                spriteBatch.Draw(images[currentIndex], rectangle, Color.White * .4f);
            }
        }
    }
}
