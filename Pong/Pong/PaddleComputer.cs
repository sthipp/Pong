using System;
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
    class PaddleComputer : Paddle
    {
        public PaddleComputer(Game game)
            : base(game)
        {
            contentManager = new ContentManager(game.Services);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            paddleSprite = contentManager.Load<Texture2D>(@"Content\Images\computerHand");
        }

        public override void Initialize()
        {
            base.Initialize();

            // Make sure base.Initialize() is called before this or handSprite will be null
            X = GraphicsDevice.Viewport.Width - Width;
            Y = (GraphicsDevice.Viewport.Height - Height) / 2;

            Speed = DEFAULT_X_SPEED;
        }

        public override void Update(GameTime gameTime)
        {
            Ball ball = Game.Components[0] as Ball;
            if (ball.Y < this.Y && this.Y - 5 > 0)
            {
                this.Y -= 5;
            }
            if (ball.Y + ball.Height > this.Y + this.Height && this.Y + this.Height + 5 < GraphicsDevice.Viewport.Height)
            {
                this.Y += 5;
            }
            base.Update(gameTime);
        }
    }
}
