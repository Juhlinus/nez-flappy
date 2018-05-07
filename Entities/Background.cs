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
        private bool _firstBackground;
        private bool _isGround;

        private float _halfBgHeight;
        
        //Inspector
        private bool _isToggled = false;
        public Background(bool firstBackground = true, bool isGround = false) : base(firstBackground ? "first_" + (isGround ? "ground" : "background") : "second_" + (isGround ? "ground" : "background")) 
        {
            _firstBackground = firstBackground;
            _isGround = isGround;
        }

        public override void onAddedToScene()
        {
            base.onAddedToScene();

            if (_isGround)
                addComponent(new BoxCollider());

            _backgroundSprite = addComponent(new Sprite(scene.content.Load<Texture2D>(_isGround ? "ground" : "background")));
            _halfBgHeight = _backgroundSprite.height / 2;

            _endPosition = new Vector2(_backgroundSprite.width + (_backgroundSprite.width / 2), _isGround ? Game1.designHeight - (_halfBgHeight / 2) : _halfBgHeight);

            if (_firstBackground)
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

        [InspectorCallable]
        public void BackgroundStop()
        {
            var entities = scene.entities;
            Vector2 speed = Vector2.Zero;

            if (_isToggled)
                speed = new Vector2(20f, 0);

            foreach (Background background in entities.entitiesOfType<Background>())
            {
                background._speed = speed; 
            }

            _isToggled = !_isToggled;
        }
    }
}