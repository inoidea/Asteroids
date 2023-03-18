using UnityEngine;

namespace Asteroids
{
    internal sealed class UFOFactory
    {
        public static Enemy CreateEnemy(float hp, Vector3 enemyPoint)
        {
            var enemy = Object.Instantiate(Resources.Load<UFO>("Enemy/UFO"), enemyPoint, Quaternion.identity);
            enemy.Health = hp;

            return enemy;
        }
    }
}
