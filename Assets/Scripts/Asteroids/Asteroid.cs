using System.Numerics;
using UnityEngine;

namespace Asteroids
{
    public sealed class Asteroid : Enemy
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            Damage.GetDamage(other.gameObject, 10);
        }
    }
}