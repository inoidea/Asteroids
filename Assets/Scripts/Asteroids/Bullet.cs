using System.Numerics;
using UnityEngine;

namespace Asteroids
{
    public sealed class Bullet : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            Damage.GetDamage(other.gameObject);
        }
    }
}
