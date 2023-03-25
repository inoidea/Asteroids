using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class BulletPool
    {
        private readonly Stack<GameObject> _pool;
        private readonly GameObject _bullet;

        private SpriteRenderer _spriteRenderer;
        private Material _bulletMaterial;

        public BulletPool(GameObject bullet)
        {
            _bullet = bullet;
            _pool = GameStarter.bulletPool;
            _spriteRenderer = Resources.Load<Bullet>("Enemy/Bullet").GetComponent<SpriteRenderer>();
            _bulletMaterial = (Material)Resources.Load("Materials/M_Bullet");
        }

        public GameObject Get(Vector3 position) {
            GameObject bullet = null;

            if (_pool.Count == 0)
            {
                var bulletBuilder = new BulletBuilder();
                bullet = bulletBuilder
                    .StartPosition(position)
                    .Name("Bullet")
                    .BulletScript()
                    .CircleCollider2D()
                    .Sprite(_spriteRenderer.sprite)
                    .Material(_bulletMaterial)
                    .ChangeScale(0.1f, 0.1f, 0.5f)
                    .ChangeMass(1);
            }
            else
            {
                bullet = _pool.Pop();
                bullet.transform.position = position;
                bullet.SetActive(true);
            }

            return bullet;
        }

        public void Return() { 
            _pool.Push(_bullet);

            _bullet.SetActive(false);
        }

        public void Dispose()
        {
            foreach (var gameObject in _pool)
            {
                Object.Destroy(gameObject);
            }

            _pool.Clear();
        }
    }
}
