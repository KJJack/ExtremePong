using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace ExtremePong
{
    public class Field
    {
        private int _score;
        private Texture2D _texture;
        private Ball _ball;
        public Ball _ball2;
        private Paddle _paddle1;
        private Paddle _paddle2;
        private Point _resolution;

        private FadeShader f_ball;
        private FadeShader f_paddle1;
        private FadeShader f_paddle2;
        private RndColorShader r_test;

        private SpriteFont f_score;
        private SpriteFont f_posX;
        private SpriteFont f_posY;

        int _score1;
        int _score2;

        Song song;

        public Field(ContentManager content, Point windowSize)
        {
            Texture2D ball = content.Load<Texture2D>("ball");
            Texture2D paddle = content.Load<Texture2D>("paddle");
            f_posX = content.Load<SpriteFont>("Pos");
            f_posY = content.Load<SpriteFont>("Pos");
            f_score = content.Load<SpriteFont>("score");
            song = content.Load<Song>("stay_retro");
            _resolution = windowSize;

            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;

            MediaPlayer.MediaStateChanged += MediaPlayer_MediaStateChanged;

            _ball = new Ball(ball);
            //_ball2 = new Ball(ball);
            _paddle1 = new Paddle(paddle);
            _paddle2 = new Paddle(paddle);

            // Shaders on objects
            f_ball = new FadeShader(_ball, .085, 0f, .05f);
            f_paddle1 = new FadeShader(_paddle1, .085, 0f, .09f);

            // Shaders test
            r_test = new RndColorShader(_ball, 1.00);

            _score1 = 0;
            _score2 = 0;

            _paddle1.Position = new Vector2(0, (_resolution.Y - _paddle1.Texture.Height) / 2);
            _paddle2.Position = new Vector2(_resolution.X - _paddle2.Texture.Width, (_resolution.Y - _paddle2.Texture.Height) / 2);
            _ball.Position = new Vector2(((_resolution.X - _ball.Texture.Width) / 2), ((_resolution.Y - _ball.Texture.Height) / 2));

            // Starting direction for ball
            _ball.Direction = new Vector2(1, 0);
       
            _paddle1.input = new Input() { Up = Keys.W, Down = Keys.S };
            _paddle2.input = new Input() { Up = Keys.O, Down = Keys.L };
        }

        void MediaPlayer_MediaStateChanged(object sender, System.EventArgs e)
        {
            MediaPlayer.Volume -= 0.1f;
            MediaPlayer.Play(song);
        }

        public void Update(GameTime gameTime)
        {
            // TODO: update player movement
            _paddle1.Update(gameTime);
            _paddle2.Update(gameTime);

            // TODO:  update ball physics
            _ball.Update(gameTime);

            f_ball.Update(gameTime);
            f_paddle1.Update(gameTime);

            // Ball hits paddle 1
            if (_ball.BoundingBox.Intersects(_paddle1.BoundingBox))
            {
                _ball.Direction = new Vector2(_ball.Direction.X * -1, _ball.Direction.Y + _paddle1.Direction.Y);
            }

            if (_ball.BoundingBox.Intersects(_paddle2.BoundingBox))
            {
                _ball.Direction = new Vector2(_ball.Direction.X * -1, _ball.Direction.Y + _paddle2.Direction.Y);
            }

            // Ball reaches left side of screen
            if (_ball.Position.X < 0)
            {
                //_ball.Position = new Vector2(0, _ball.Position.Y);
                //_ball.Direction = new Vector2(-1 * _ball.Direction.X,
                //    _ball.Direction.Y);

                _score2++;
                ResetGame();
            }

            // Ball reaches right side of screen
            if (_ball.Position.X > _resolution.X -
                _ball.BoundingBox.Width)
            {
                //_ball.Position = new Vector2(
                //    _resolution.X - _ball.BoundingBox.Width,
                //    _ball.Position.Y);
                //_ball.Direction = new Vector2(
                //    -1 * _ball.Direction.X, _ball.Direction.Y);

                _score1++;
                ResetGame();
            }

            // Ball reaches top side of screen
            if (_ball.Position.Y < 0)
            {
                _ball.Position = new Vector2(_ball.Position.X, 0);
                _ball.Direction = new Vector2(
                    _ball.Direction.X,
                    _ball.Direction.Y * -1);
            }

            // Ball reaches bottom side of screen
            if (_ball.Position.Y > _resolution.Y -
                _ball.BoundingBox.Height)
            {
                _ball.Position = new Vector2(
                    _ball.Position.X, _resolution.Y -
                    _ball.BoundingBox.Height);
                _ball.Direction = new Vector2(
                    _ball.Direction.X, -1 * _ball.Direction.Y);
            }
        }

        public void ResetGame()
        {
            _paddle1.Position = new Vector2(0, (_resolution.Y - _paddle1.Texture.Height) / 2);
            _paddle2.Position = new Vector2(_resolution.X - _paddle2.Texture.Width, (_resolution.Y - _paddle2.Texture.Height) / 2);
            _ball.Position = new Vector2(((_resolution.X - _ball.Texture.Width) / 2), ((_resolution.Y - _ball.Texture.Height) / 2));

            // Starting direction for ball
            _ball.Direction = new Vector2(1, 0);
            _ball.Speed = 440f;
        }

        public void Draw(GameTime gameTime, SpriteBatch batch)
        {
            batch.Begin();

            //_paddle1.Draw(gameTime, batch);
            _paddle2.Draw(gameTime, batch);

            // Testing different shader values on paddles
            f_paddle1.Draw(gameTime, batch);

            r_test.Draw(gameTime, batch);
            // normal ball
            //_ball.Draw(gameTime, batch);

            // fade ball
            f_ball.Draw(gameTime, batch);

            batch.DrawString(f_posX, "Pos X" + _ball.Direction.X.ToString(), new Vector2(100, 100), Color.White);
            batch.DrawString(f_posX, "Pos Y" + _ball.Direction.Y.ToString(), new Vector2(100, 150), Color.White);

            batch.DrawString(f_posX, "Pos Y" + _paddle2.Direction.Y.ToString(), new Vector2(100, 200), Color.White);

            batch.DrawString(f_score, "SCORE: " + _score1.ToString() + " | " + _score2.ToString(), new Vector2((_resolution.X / 2), 100), Color.AliceBlue);

            batch.End();
        }
    }
}