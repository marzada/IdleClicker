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
    public class Subscribe
    {
        Rectangle buttonRect;
        Texture2D subscribeImage;

        Game1 game;

        public Subscribe(Game1 _game)
        {
            game = _game;
            buttonRect = new Rectangle(0, 372, 200, 55);
            subscribeImage = game.subscribe;
        }

        public virtual void update(GameTime gameTime)
        {
            if (game.position.X > buttonRect.X &&
                game.position.X < buttonRect.X + buttonRect.Width &&
                game.position.Y > buttonRect.Y &&
                game.position.Y < buttonRect.Y + buttonRect.Height)
            {
                if(game.mouseState.LeftButton == ButtonState.Pressed &&
                   game.lastMouseState == false)
                {
                    game.player.doubleBits += game.player.bitsPerClick;
                }
            }
        }

        public virtual void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(subscribeImage, buttonRect, Color.White);
        }
    }
}
