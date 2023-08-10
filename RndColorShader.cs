using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;

namespace ExtremePong
{
    public class RndColorShader
    {
        public GameObject _obj;
        public Random _rnd;
        double _delay;
        double _delayReset;

        public Color[] color =
        {
            Color.White,
            Color.Red,
            Color.Blue,
            Color.Green,
            Color.Yellow,
            Color.Orange,
            Color.Purple,
        };

        public RndColorShader(GameObject _obj, double _delay)
        {
            this._obj = _obj;
            this._delay = _delay;
            this._delayReset = _delay;
        }

        public void Draw(GameTime _gameTime, SpriteBatch _batch)
        {
            _delay -= _gameTime.ElapsedGameTime.TotalSeconds;
            
            if (_delay <= 0 )
            {
                _delay = _delayReset;

                _batch.Draw(_obj.Texture, _obj.Position, RandomColor());
            }
        }

        public Color RandomColor()
        {
            _rnd = new Random();
            int _ind = _rnd.Next(0, color.Length);
            return color[_ind];
        }
    }
}