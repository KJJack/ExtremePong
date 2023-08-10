using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace ExtremePong
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteBatch _spriteBatch2;

        private Field _field;
        Texture2D fade;
        float alphaVal = 0;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 1600;
            _graphics.PreferredBackBufferHeight = 1000;
            _graphics.ApplyChanges();

            fade = Content.Load<Texture2D>("ball");

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _spriteBatch2= new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _field = new Field(Content, new Point(1600, 1000));
        }

        double fadeDelay = .075;
        bool fadeonoff = false;

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //fadeDelay -= gameTime.ElapsedGameTime.TotalSeconds;

            //if (fadeDelay <= 0)
            //{
            //    fadeDelay = .075;
            //    // TODO: Add your update logic here
            //    if (alphaVal <= 1.0f && fadeonoff == false)
            //    {
            //        alphaVal += 0.15f;
            //        Debug.WriteLine(alphaVal);

            //        if (alphaVal >= 1.0f)
            //            fadeonoff = true;
            //    }

            //    if (alphaVal >= 0.2f && fadeonoff == true)
            //    {
            //        alphaVal -= 0.05f;

            //        Debug.WriteLine(alphaVal);

            //        if (alphaVal <= 0.2f)
            //            fadeonoff = false;
            //    }


            //}

          
            _field.Update(gameTime);

            base.Update(gameTime);

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            //_spriteBatch2.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied);
            //_spriteBatch2.Draw(fade,
            //    new Rectangle(0, 0, fade.Width, fade.Height),
            //    Color.White * alphaVal);
            //_spriteBatch2.End();

            _field.Draw(gameTime, _spriteBatch);

            base.Draw(gameTime);
        }
    }
}