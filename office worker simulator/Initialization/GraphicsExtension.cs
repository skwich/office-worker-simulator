using Microsoft.Xna.Framework;

namespace office_worker_simulator.Initialization;

public static class GraphicsExtension
{
    public static GraphicsDeviceManager InitializeDisplayMode(this GraphicsDeviceManager graphics)
    {
        graphics.PreferredBackBufferWidth = 1280;
        graphics.PreferredBackBufferHeight = 720;
        graphics.IsFullScreen = true;
        return graphics;
    }
}