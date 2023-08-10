using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using System.Diagnostics;

namespace ExtremePong
{
    public class FadeShader
    {
        public GameObject _obj;
        double _delay;
        double _delayReset;
        float _alphalevel;
        float _alphaRate;

        bool _fadeSwitch = false;

        public FadeShader(GameObject obj, double delay, float alphaStart, float alphaRate)
        {
            this._obj = obj;
            this._delay = delay;
            this._delayReset = delay;
            this._alphalevel = alphaStart;
            this._alphaRate = alphaRate;
        }

        // Draw(Texture, Position/Rectangle, Color.White * alpha)

        public void Update(GameTime gameTime)
        {
            _delay -= gameTime.ElapsedGameTime.TotalSeconds;
            Debug.WriteLine(gameTime.ElapsedGameTime.TotalSeconds);

            if (_delay <= 0)
            {
                _delay = _delayReset;

                // fade in
                if (_alphalevel <= 1.0f && _fadeSwitch == false)
                {
                    _alphalevel += _alphaRate;

                    if (_alphalevel >= 1.0f)
                    {
                        _fadeSwitch = true;
                    }
                }

                // fade out
                if (_alphalevel >= 0.0f && _fadeSwitch == true)
                {
                    _alphalevel -= _alphaRate;

                    if (_alphalevel <= 0.0f) 
                    {
                        _fadeSwitch = false;
                    }
                }
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch fs_batch)
        {
            //fs_batch.Draw(_obj.Texture, new Rectangle(50, 50, _obj.Texture.Width, _obj.Texture.Height), Color.Red * _alphalevel);
            fs_batch.Draw(_obj.Texture, _obj.Position, Color.White * _alphalevel);

        }
    }
}