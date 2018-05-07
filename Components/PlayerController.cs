using System;
using Microsoft.Xna.Framework.Input;
using Nez;

namespace FlappyFlop.Components
{
    class PlayerController : Component, ITriggerListener, IUpdatable
    {
        VirtualButton _buttonInput = new VirtualButton();

        public override void onAddedToEntity()
        {
            _buttonInput.addKeyboardKey(Keys.Space);
        }

        public void update()
        {
            if (_buttonInput != null)
            {
                if (_buttonInput.isPressed)
                {
                    var player = entity as Entities.Player;
                    player._velocity = -.2f;
                    player.localRotationDegrees = -160f;
                }
            }
        }

        public void onTriggerEnter(Collider other, Collider local)
        {
            Console.WriteLine("DONT TOUCH ME");
        }

        public void onTriggerExit(Collider other, Collider local)
        {
            throw new NotImplementedException();
        }
    }
}