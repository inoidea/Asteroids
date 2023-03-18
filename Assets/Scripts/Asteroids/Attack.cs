using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Asteroids
{
    internal sealed class Attack
    {
        public static void Fire(Rigidbody2D bullet, Transform startPosition, float force = 500)
        {
            //Bullet bullet1 = Resources.Load<Bullet>("Enemy/Asteroid");
            //GameObject bulletObj = bullet1.Get();
            //var temAmmunition = Object.Instantiate(bulletObj).GetComponent<Rigidbody2D>();

            var temAmmunition = Object.Instantiate(bullet, startPosition.position, startPosition.rotation);
            temAmmunition.AddForce(startPosition.up * force);
        }
    }
}
