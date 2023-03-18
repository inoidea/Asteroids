using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class Bullet: MonoBehaviour
    {
        private readonly Stack<GameObject> _pool = new Stack<GameObject>();
        private readonly GameObject _bullet;

        public Bullet(GameObject bullet)
        {
            _bullet = bullet;
        }

        public GameObject Get() { 
            GameObject result = (_pool.Count == 0) ? Instantiate(_bullet) : _pool.Pop();

            return result;
        }

        public void Return(GameObject gameObject) { 
            _pool.Push(gameObject);
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
