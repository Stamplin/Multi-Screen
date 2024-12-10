using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mutiscreen
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D tribbleBrownTexture;

        Texture2D tribbleCreamTexture;

        Texture2D tribbleGreyTexture;
        Rectangle tribbleGreyRect;
        Vector2 tribbleGreySpeed;

        Texture2D tribbleOrangeTexture;

        Texture2D tribbleIntroTexture;

        Texture2D introText;

        Texture2D endTexture;

        SoundEffect sound;

        enum Screen
        {
            Intro,
            TribbleYard,
            End
        }

        Screen screen;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Content.RootDirectory = "Content";
            this.Window.Title = "Lesson 3 - Animation Part 1";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = 800;  // set this value to the desired width of your window
            _graphics.PreferredBackBufferHeight = 500;   // set this value to the desired height of your window
            _graphics.ApplyChanges();

            tribbleGreyRect = new Rectangle(300, 10, 100, 100);
            tribbleGreySpeed = new Vector2(2, 0);

            screen = Screen.Intro;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");
            tribbleCreamTexture = Content.Load<Texture2D>("tribbleCream");
            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleOrange");
            tribbleIntroTexture = Content.Load<Texture2D>("tribble_intro");
            introText = Content.Load<Texture2D>("text");
            endTexture = Content.Load<Texture2D>("end");
            sound = Content.Load<SoundEffect>("Gong Sound Effect");
        }

        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (screen == Screen.Intro)
            {
                //press enter to go the next screen
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                    screen = Screen.TribbleYard;
            }
            else if (screen == Screen.TribbleYard)
            {
                sound.Play();
                tribbleGreyRect.X += (int)tribbleGreySpeed.X;
                tribbleGreyRect.Y += (int)tribbleGreySpeed.Y;

                if (tribbleGreyRect.Right > _graphics.PreferredBackBufferWidth || tribbleGreyRect.X < 0)
                    tribbleGreySpeed.X *= -1;
                    

                if (tribbleGreyRect.Bottom > _graphics.PreferredBackBufferHeight || tribbleGreyRect.Top < 0)
                    tribbleGreySpeed.Y *= -1;
            }



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(tribbleIntroTexture, new Rectangle(0, 0, 800, 500), Color.White);
                _spriteBatch.Draw(introText, new Rectangle(0, 0, 660, 150), Color.White);
            }
            else if (screen == Screen.TribbleYard)
            {
                _spriteBatch.Draw(tribbleGreyTexture, tribbleGreyRect, Color.White);
                //_spriteBatch.Draw(introText, new Rectangle(300, 600, 660, 150), Color.Red);
            }
            else if (screen == Screen.End) 
            {
                _spriteBatch.Draw(endTexture, new Rectangle(0, 0, 800, 500), Color.White);

            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}