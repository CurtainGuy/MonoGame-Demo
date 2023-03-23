using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer2D.Core.Game
{
    class Bullet
    {
        public Vector2 Position { get; private set; }
        public Vector2 Velocity { get; private set; }
        private AnimationPlayer sprite;
        private Animation bulletAnimation;
        private float rotation;
        
        private Rectangle localBounds;
        /// <summary>
        /// Gets a rectangle which bounds this player in world space.
        /// </summary>
        public Rectangle BoundingRectangle
        {
            get
            {
                int left = (int)Math.Round(Position.X - sprite.Origin.X) + localBounds.X;
                int top = (int)Math.Round(Position.Y - sprite.Origin.Y) + localBounds.Y;

                return new Rectangle(left, top, localBounds.Width, localBounds.Height);
            }
        }

        private const float ShootVelocity = 1000.0f;
        private readonly Level Level;

        public Bullet(Level level, Vector2 startPosition, Vector2 direction)
        {
            Position = startPosition;
            Velocity = -direction * ShootVelocity;
            Level = level;
            bulletAnimation = new Animation(Level.Content.Load<Texture2D>("Sprites/Bullet"), 0.1f, false);
            sprite.PlayAnimation(bulletAnimation);

            // Calculate bounds within texture size.            
            int width = (int)(bulletAnimation.FrameWidth * 0.4);
            int left = (bulletAnimation.FrameWidth - width) / 2;
            int height = (int)(bulletAnimation.FrameHeight * 0.8);
            int top = bulletAnimation.FrameHeight - height;
            localBounds = new Rectangle(left, top, width, height);

            rotation = (float)Math.Atan2(-direction.Y, -direction.X);
        }

        public void Update(GameTime gameTime)
        {
            Position += Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // Draw that sprite.
            sprite.Draw(gameTime, spriteBatch, Position, SpriteEffects.None, rotation);
        }
    }
}
