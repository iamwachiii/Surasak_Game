using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Penumbra;
using SK_03;
using System;
namespace SK_03
{
    public class Littleghost : Sprite
    {
        public int LittleghostWidth, LittleghostHeight;
        public Rectangle sourceRectangle, destinationRectangle;
        public Vector2 Littleghost_pos;

        private int totalFrames, currentFrame;
        private double timePerFrame, elapsedTime;
        private Texture2D texture;
        private Game1 game;
        private Color tranparentColor;


        public Littleghost(Game1 game, Texture2D texture, Vector2 position)
        {
            this.game = game;
            this.texture = texture;
            this.totalFrames = 4;
            this.currentFrame = 0;
            this.timePerFrame = 250;
            this.elapsedTime = 0;

            this.Littleghost_pos = position;
            LittleghostWidth = texture.Width / 4;
            LittleghostHeight = texture.Height;

            sourceRectangle = new Rectangle(0, 0, LittleghostWidth, LittleghostHeight);
            destinationRectangle = new Rectangle((int)Littleghost_pos.X, (int)Littleghost_pos.Y, LittleghostWidth, LittleghostHeight);

            tranparentColor = new Color(255, 255, 255) * 0.7f;
        }
        public override void Update(GameTime gameTime)
        {
            // Update destination rectangle based on candle position
            destinationRectangle.X = (int)Littleghost_pos.X;
            destinationRectangle.Y = (int)Littleghost_pos.Y;

            // Update the candle animation
            elapsedTime += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (elapsedTime >= timePerFrame)
            {
                currentFrame = (currentFrame + 1) % totalFrames;
                elapsedTime = 0;
                sourceRectangle.X = currentFrame * LittleghostWidth;
            }

            base.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, tranparentColor);
        }
    }
}



