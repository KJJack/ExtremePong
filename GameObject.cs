using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ExtremePong
{
    public class GameObject
    {
        public Vector2 Position { get; set; }
        public Vector2 Direction { get; set; }
        public float Speed { get; set; }
        public Texture2D Texture { get; set; }
        public Color Tint { get; set; }

        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle(
                    (int)Position.X,
                    (int)Position.Y,
                    Texture.Width,
                    Texture.Height);
            }
        }

        public GameObject(Texture2D texture)
        {
            Position = Vector2.Zero;
            Direction = Vector2.Zero;
            Speed = 0f;
            Texture = texture;
            Tint = Color.White;
        }

        public virtual void Update(GameTime gameTime)
        {
            if (Direction != Vector2.Zero)
                Direction.Normalize();

            Position += Direction * Speed *
                (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch batch)
        {
            batch.Draw(Texture, Position, Tint);
        }
    }
}