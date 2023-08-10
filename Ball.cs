using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtremePong
{
    public class Ball : GameObject
    {
        public Ball(Texture2D texture) : base(texture)
        {
            Speed = 440f;
        }
    }
}
