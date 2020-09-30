using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using IdleClicker.Source;


namespace IdleClicker
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Object declarations
        public Player player;
        public Subscribe subscribeButton;
        public BitGenerators[] bitGenerators;
        public Upgrades[] upgrades;

        //Constants to be used and referenced throughout
        public Texture2D bits1;
        public Texture2D bits100;
        public Texture2D bits1000;
        public Texture2D bits5000;
        public Texture2D bits10000;
        public Texture2D bits100000;
        public Texture2D poggers;
        public Texture2D subscribe;
        public Texture2D tier2Sub;
        public Texture2D tier3Sub;
        public Texture2D stopwatch;
        public Texture2D clicker;
        public Texture2D poggersSS1;
        public Texture2D poggersSS2;

        public SpriteFont InfoFont24;
        public SpriteFont InfoFont48;

        public MouseState mouseState;
        public bool lastMouseState;
        public Vector2 position;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 400;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 640;   // set this value to the desired height of your window
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.IsMouseVisible = true;
            lastMouseState = false;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            bits1 = this.Content.Load<Texture2D>("bits1.png");
            bits100 = this.Content.Load<Texture2D>("bits100.png");
            bits1000 = this.Content.Load<Texture2D>("bits1000.png");
            bits10000 = this.Content.Load<Texture2D>("bits10000.png");
            bits100000 = this.Content.Load<Texture2D>("bits100000.png");
            bits5000 = this.Content.Load<Texture2D>("bits5000.png");
            poggers = this.Content.Load<Texture2D>("poggers.png");
            subscribe = this.Content.Load<Texture2D>("subscribe.png");
            tier2Sub = this.Content.Load<Texture2D>("tier2Sub.png");
            tier3Sub = this.Content.Load<Texture2D>("tier3Sub.png");
            stopwatch = this.Content.Load<Texture2D>("stopwatch.png");
            clicker = this.Content.Load<Texture2D>("clicker.png");
            poggersSS1 = this.Content.Load<Texture2D>("poggersSS1.png");
            poggersSS2 = this.Content.Load<Texture2D>("poggersSS2.png");

            InfoFont24 = this.Content.Load<SpriteFont>("InfoFont24");
            InfoFont48 = this.Content.Load<SpriteFont>("InfoFont48");

            player = new Player(this);
            subscribeButton = new Subscribe(this);
            bitGenerators = new BitGenerators[]{
                new BitGenerators(this, poggers, new Rectangle(200, 240, 80, 80), 10, 1)
            };
            upgrades = new Upgrades[]{
                new ClickerMultipliers(this, new Rectangle(0, 560, 80, 80)),
                new PoggersMultipliers(this, new Rectangle(80, 560, 80, 80))
            };
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            mouseState = Mouse.GetState();
            position.X = mouseState.X;
            position.Y = mouseState.Y;

            player.update(gameTime);
            subscribeButton.update(gameTime);
            for(int i = 0; i < bitGenerators.Length; i++)
            {
                bitGenerators[i].update(gameTime);
            }
            for(int i = 0; i < upgrades.Length; i++)
            {
                upgrades[i].update(gameTime);
            }

            if(mouseState.LeftButton == ButtonState.Pressed)
            {
                lastMouseState = true;
            }
            else
            {
                lastMouseState = false;
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            player.draw(spriteBatch);
            subscribeButton.draw(spriteBatch);
            for (int i = 0; i < bitGenerators.Length; i++)
            {
                bitGenerators[i].draw(spriteBatch);
            }
            for (int i = 0; i < upgrades.Length; i++)
            {
                upgrades[i].draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
