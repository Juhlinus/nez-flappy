using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace FlappyFlop.Entities
{
    class Background : Entity
    {
        private Vector2 _speed = new Vector2(20f, 0);
        private Sprite _backgroundSprite;
        private bool _firstPlayer;
        private Vector2 _endPosition;
        public Background(bool firstPlayer = true) : base(firstPlayer ? "first_background" : "second_background") 
        {
            _firstPlayer = firstPlayer;
        }

        public override void onAddedToScene()
        {
            base.onAddedToScene();

            _backgroundSprite = addComponent(new Sprite(scene.content.Load<Texture2D>("background")));
            _endPosition = new Vector2(_backgroundSprite.width + (_backgroundSprite.width / 2), _backgroundSprite.height / 2);

            if (_firstPlayer)
            {
                transform.position = new Vector2((_backgroundSprite.width / 2), _backgroundSprite.height / 2);
            }
            else
            {
                transform.position = _endPosition;
            }
        }

        public override void update()
        {
            base.update();

            if (transform.position.X < -(_backgroundSprite.width / 2))
            {
                transform.position = _endPosition;
            }
            
            transform.position += -(_speed * 5) * Time.deltaTime;
        }
    }
}