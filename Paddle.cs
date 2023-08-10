using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtremePong
{
    public class Paddle : GameObject
    {
        public Input input;

        public Paddle(Texture2D texture) : base(texture)
        {
            Speed = 400f;
        }

        public override void Update(GameTime gameTime)
        {
            Direction = Vector2.Zero;

            if (Keyboard.GetState().IsKeyDown(input.Up))
            {
                Direction = new Vector2(0, -1);
            }

            if (Keyboard.GetState().IsKeyDown(input.Down))
            {
                Direction = new Vector2(0, 1);
            }


            base.Update(gameTime);
        }
    }
}
