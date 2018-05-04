using Nez;
using static Nez.Scene;

namespace FlappyFlop
{
    public class Game1 : Core
    {
        public Game1() { }

        protected override void Initialize()
        {
            base.Initialize();

            Nez.Console.DebugConsole.consoleKey = Microsoft.Xna.Framework.Input.Keys.F2;

            setDefaultDesignResolution(512, 288, SceneResolutionPolicy.BestFit);

            scene = new Scenes.Level();
        }
    }
}
