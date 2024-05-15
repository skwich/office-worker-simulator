using Microsoft.Xna.Framework;

namespace office_worker_simulator.Initialization;

public static class GraphicsExtension
{
    public static GraphicsDeviceManager InitializeDisplayMode(this GraphicsDeviceManager graphics)
    {
        // var currentDisplayMode = graphics.GraphicsDevice.DisplayMode;
        graphics.PreferredBackBufferWidth = 1280;
        graphics.PreferredBackBufferHeight = 720;
        return graphics;
    }
}