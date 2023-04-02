using System.Numerics;
using UnityEngine;

namespace Asteroids
{
    public sealed class Bullet : MonoBehaviour
    {
        public float _amount = 1;

        private void OnCollisionEnter2D(Collision2D other)
        {
            Damage.GetDamage(other.gameObject, _amount);
        }
    }
}
