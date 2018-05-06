using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace FlappyFlop.Entities
{
    class Player : Entity
    {
        private const float GRAVITY = 0.5f;
        private float _velocity = 0f;

        public Player() : base("player")
        {
        }

        public override void onAddedToScene()
        {
            base.onAddedToScene();

            addComponent(new Sprite(scene.content.Load<Texture2D>("bird")));
            addComponent(new BoxCollider());

            transform.position = new Vector2(Game1.designWidth / 2, Game1.designHeight / 2);
        }

        public override void update()
        {
            base.update();

            _velocity = _velocity + GRAVITY * Time.deltaTime;

            transform.position = new Vector2(transform.position.X, transform.position.Y + _velocity);
        }
    }
}