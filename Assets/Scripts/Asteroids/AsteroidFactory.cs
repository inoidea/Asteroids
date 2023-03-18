using UnityEngine;

namespace Asteroids
{
    internal sealed class AsteroidFactory : IEnemyFactory
    {
        public Enemy Create(float hp)
        {
            var enemy = Object.Instantiate(Resources.Load<Asteroid>("Enemy/Asteroid"));
            enemy.DependencyInjectHealth(hp);

            return enemy;
        }
    }
}
