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
        private Vector2 _endPosition;

        private Sprite _backgroundSprite;
        private bool _firstPlayer;
        private bool _isGround;

        private float _halfBgHeight;
        public Background(bool firstPlayer = true, bool isGround = false) : base(firstPlayer ? "first_" + (isGround ? "ground" : "background") : "second_" + (isGround ? "ground" : "background")) 
        {
            _firstPlayer = firstPlayer;
            _isGround = isGround;
        }

        public override void onAddedToScene()
        {
            base.onAddedToScene();

            _backgroundSprite = addComponent(new Sprite(scene.content.Load<Texture2D>(_isGround ? "ground" : "background")));
            _halfBgHeight = _backgroundSprite.height / 2;

            _endPosition = new Vector2(_backgroundSprite.width + (_backgroundSprite.width / 2), _isGround ? Game1.designHeight - (_halfBgHeight / 2) : _halfBgHeight);

            if (_firstPlayer)
            {
                transform.position = new Vector2((_backgroundSprite.width / 2), _isGround ? Game1.designHeight - (_halfBgHeight / 2) : _halfBgHeight);
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

            transform.position += -((_isGround ? _speed / 2 : _speed) * 5) * Time.deltaTime;
        }
    }
}