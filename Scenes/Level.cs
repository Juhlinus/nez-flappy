using Nez;

namespace FlappyFlop.Scenes
{
    class Level : Scene
    {
        public override void initialize()
        {
            base.initialize();

            addRenderer(new DefaultRenderer());

            addEntity(new Entities.Background());
            addEntity(new Entities.Background(false));
        }
    }
}