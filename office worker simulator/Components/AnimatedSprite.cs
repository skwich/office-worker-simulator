using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace office_worker_simulator.Components;

public class AnimatedSprite
{
    private readonly Texture2D[] textures;
    private double lastTime;
    private int counter;

    public AnimatedSprite(Texture2D[] textures)
    {
        this.textures = textures ?? throw new NullReferenceException();
    }

    public Texture2D GetTexture(GameTime gameTime, int speedTime)
    {
        if (gameTime.TotalGameTime.TotalMilliseconds - lastTime >= speedTime)
        {
            counter = counter >= textures.Length - 1 ? 0 : counter + 1;
            lastTime = gameTime.TotalGameTime.TotalMilliseconds;
        }
        
        return textures[counter];
    }

    public void Reset()
    {
        counter = 0;
        lastTime = 0;
    }
}