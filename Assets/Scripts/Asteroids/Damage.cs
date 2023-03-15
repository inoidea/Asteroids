using UnityEngine;

namespace Asteroids
{
    internal sealed class Damage
    {
        public static void GetDamage(GameObject target, float amount = 1) {
            var unit = target.GetComponent<IHealth>();

            if (unit != null)
            {
                if (unit.Health <= 0)
                {
                    Object.Destroy(target);
                }
                else
                {
                    unit.Health -= amount;
                }
            }
        }
    }
}
