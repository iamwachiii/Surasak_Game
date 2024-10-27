using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Penumbra;
using SK_03;
using System;

public class Candle : Sprite
{
    public int candleWidth, candleHeight;
    public Rectangle sourceRectangle, destinationRectangle;
    public Vector2 candle_pos;

    private int totalFrames, currentFrame;
    private double timePerFrame, elapsedTime;
    private Texture2D texture;
    private Game1 game;

    // Add PointLight to Candle
    private PointLight candleLight;
    private bool isLightInitialized = false;

    // Oscillation variables for flame flicker effect
    private float candleLightTimer = 0f;
    private float candleLightOscillationSpeed = 10f;  // Speed for flicker
    private float candleLightOscillationAmount = 10f; // Increased movement for more dramatic flicker
    private Random random = new Random();
    private bool candleIsActive = true;

    public Candle(Game1 game, Texture2D texture, Vector2 position)
    {
        this.game = game;
        this.texture = texture;
        this.totalFrames = 4;
        this.currentFrame = 0;
        this.timePerFrame = 100;
        this.elapsedTime = 0;

        this.candle_pos = position;
        candleWidth = texture.Width / 4;
        candleHeight = texture.Height;

        sourceRectangle = new Rectangle(0, 0, candleWidth, candleHeight);
        destinationRectangle = new Rectangle((int)candle_pos.X, (int)candle_pos.Y, candleWidth, candleHeight);

        InitializeCandleLight();
    }

    public void InitializeCandleLight()
    {
        if (!isLightInitialized)
        {
            candleLight = new PointLight
            {
                Scale = new Vector2(200f),
                ShadowType = ShadowType.Solid,
                Intensity = 1.5f,
                Color = new Color(255, 0, 0, 255),
                Enabled = true
            };
            game._penumbra.Lights.Add(candleLight);
            isLightInitialized = true;
        }
    }

    public void UpdateCandleLight(GameTime gameTime)
    {
        if (candleLight != null && isLightInitialized)
        {
            candleLightTimer += (float)gameTime.ElapsedGameTime.TotalSeconds * candleLightOscillationSpeed;

            float oscillationOffset = (float)Math.Sin(candleLightTimer) * candleLightOscillationAmount
                                      + (float)(random.NextDouble() - 0.5) * 2;

            // Update the light position to follow the candle
            candleLight.Position = candle_pos - game.cameraPos + new Vector2(candleWidth / 2, 20 + oscillationOffset);
        }
    }
    public void ExtinguideCandle()
    {
        currentFrame = 0;
        CleanupLight();
        candleIsActive = !candleIsActive;
    }


    public override void Update(GameTime gameTime)
    {
        // Update destination rectangle based on candle position
        destinationRectangle.X = (int)candle_pos.X;
        destinationRectangle.Y = (int)candle_pos.Y;

        // Update the candle animation
        if (candleIsActive == true)
        {
            elapsedTime += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (elapsedTime >= timePerFrame)
            {
                currentFrame = (currentFrame + 1) % totalFrames;
                elapsedTime = 0;
                sourceRectangle.X = currentFrame * candleWidth;
            }

            UpdateCandleLight(gameTime);
        }

        base.Update(gameTime);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
    }

    public void CleanupLight()
    {
        if (candleLight != null && isLightInitialized)
        {
            game._penumbra.Lights.Remove(candleLight);
            candleLight = null;
            isLightInitialized = false;
        }
    }
}


