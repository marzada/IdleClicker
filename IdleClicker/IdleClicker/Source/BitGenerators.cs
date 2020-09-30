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
    public class BitGenerators
    {
        public Rectangle rectangle;
        public Rectangle clickableArea;
        public Texture2D image;
        public int cost;
        public int amount;
        public int numOwned;

        public Game1 game;

        public BitGenerators(Game1 _game, Texture2D _image, Rectangle _rectangle, int _cost, int _amount)
        {
            game = _game;
            image = _image;
            cost = _cost;
            amount = _amount;
            rectangle = _rectangle;
            numOwned = 0;
            clickableArea = new Rectangle(rectangle.X, rectangle.Y, 200, 80);
        }

        public virtual void update(GameTime gameTime)
        {
            if (game.position.X > clickableArea.X &&
                game.position.X < clickableArea.X + clickableArea.Width &&
                game.position.Y > clickableArea.Y &&
                game.position.Y < clickableArea.Y + clickableArea.Height)
            {
                if (game.mouseState.LeftButton == ButtonState.Pressed &&
                   game.lastMouseState == false)
                {
                    if (game.player.doubleBits >= cost)
                    {
                        game.player.doubleBits -= cost;
                        cost = (int)(1.3 * cost);
                        game.player.bitsPerSecond += amount;
                        numOwned++;
                    }
                }
            }
        }

        public virtual void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, rectangle, Color.White);
            spriteBatch.DrawString(game.InfoFont24, "$" + cost.ToString(), new Vector2(rectangle.X + rectangle.Width + 5, rectangle.Y), Color.Black);
            spriteBatch.DrawString(game.InfoFont24, "+" + (amount * numOwned).ToString(), new Vector2(rectangle.X + rectangle.Width + 5, rectangle.Y + 40), Color.Black);
        }
    }
}
