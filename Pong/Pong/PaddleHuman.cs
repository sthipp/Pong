﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Pong
{
    class PaddleHuman : Paddle
    {
        public PaddleHuman(Game game)
            : base(game)
        {
            contentManager = new ContentManager(game.Services);
        }
        public override void Update(GameTime gameTime)
        {
            // Scale the movement based on time
            float moveDistance = Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Move paddle, but don't allow movement off the screen

            KeyboardState newKeyState = Keyboard.GetState();
            if (newKeyState.IsKeyDown(Keys.Down) && Y + paddleSprite.Width
                + moveDistance <= GraphicsDevice.Viewport.Height)
            {
                Y += moveDistance;
            }
            else if (newKeyState.IsKeyDown(Keys.Up) && Y - moveDistance >= 0)
            {
                Y -= moveDistance;
            }

            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            paddleSprite = contentManager.Load<Texture2D>(@"Content\Images\hand");
        }

        public override void Initialize()
        {
            base.Initialize();

            // Make sure base.Initialize() is called before this or handSprite will be null
            X = 0;
            Y = (GraphicsDevice.Viewport.Height - Height) / 2;

            Speed = DEFAULT_X_SPEED;
        }
    }
}
