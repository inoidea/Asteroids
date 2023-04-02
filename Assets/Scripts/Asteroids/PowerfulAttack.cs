using UnityEngine;

namespace Asteroids
{
    internal class PowerfulAttack : IAttack
    {
        private float _amount = 10;

        public void Attack()
        {
            Debug.Log("мощный пиу");
        }

        public void Attack(GameObject bulletPref, Transform startPosition, float force = 700)
        {
            var bullet = new BulletPool(bulletPref).Get(startPosition.position);
            bullet.GetComponent<Rigidbody2D>().AddForce(startPosition.up * force);
            bullet.GetComponent<Bullet>()._amount = _amount;
        }
    }
}
