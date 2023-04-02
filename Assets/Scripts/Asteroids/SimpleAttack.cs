using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Asteroids
{
    internal sealed class SimpleAttack
    {
        public static void Attack(GameObject bulletPref, Transform startPosition, float force = 500)
        {
            var bullet = new BulletPool(bulletPref).Get(startPosition.position);
            bullet.GetComponent<Rigidbody2D>().AddForce(startPosition.up * force);
        }
    }
}
