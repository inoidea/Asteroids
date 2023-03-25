using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Asteroids
{
    internal class BulletBuilder
    {
        protected GameObject _bullet;

        public BulletBuilder() { 
            _bullet = new GameObject();
        }

        protected BulletBuilder(GameObject bullet) {
            _bullet = bullet;
        }

        public BulletBuilder Name(string name)
        {
            _bullet.name = name;

            return this;
        }

        public BulletBuilder Sprite(Sprite sprite)
        {
            var component = GetOrAddComponent<SpriteRenderer>();
            component.sprite = sprite;

            return this;
        }

        public BulletBuilder Material(Material material)
        {
            var component = GetOrAddComponent<SpriteRenderer>();
            component.material = material;

            return this;
        }

        public BulletBuilder ChangeMass(float mass)
        {
            var component = GetOrAddComponent<Rigidbody2D>();
            component.mass = mass;

            return this;
        }

        public BulletBuilder ChangeForce(Transform startPosition, float force)
        {
            var component = GetOrAddComponent<Rigidbody2D>();
            component.AddForce(startPosition.up * force);

            return this;
        }

        public BulletBuilder StartPosition(Vector3 startPosition)
        {
            var component = GetOrAddComponent<Transform>();
            component.Translate(startPosition - component.position);

            return this;
        }

        public BulletBuilder ChangeScale(float x, float y, float z)
        {
            var component = GetOrAddComponent<Transform>();
            component.localScale = new Vector3(x, y, z);

            return this;
        }

        public BulletBuilder CircleCollider2D()
        {
            GetOrAddComponent<CircleCollider2D>();

            return this;
        }

        public BulletBuilder BulletScript()
        {
            GetOrAddComponent<Bullet>();

            return this;
        }

        private T GetOrAddComponent<T>() where T : Component
        {
            var result = _bullet.GetComponent<T>();

            if (!result)
            {
                result = _bullet.AddComponent<T>();
            }

            return result;
        }

        public static implicit operator GameObject(BulletBuilder builder)
        {
            return builder._bullet;
        }
    }
}
