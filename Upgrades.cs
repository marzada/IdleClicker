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
    public class Upgrades
    {
        public Rectangle rectangle;

        public Game1 game;

        public Upgrades(Game1 _game, Rectangle _rectangle)
        {
            game = _game;
            rectangle = _rectangle;
        }

        public virtual void update(GameTime gameTime)
        {
        }

        public virtual void draw(SpriteBatch spriteBatch)
        {
        }
    }
}
