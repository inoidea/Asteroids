using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class GameStarter : MonoBehaviour
    {
        [SerializeField] private Transform[] _enemyPointList;
        public static Stack<GameObject> bulletPool = new Stack<GameObject>();

        private void Start()
        {
            Enemy.CreateAsteroidEnemy(100, GetEnemyPoint().position);

            Enemy original = UFOFactory.CreateEnemy(100, GetEnemyPoint().position);

            Enemy prototype = (Enemy)original.Clone();
            prototype.DependencyInjectHealth(40);
            Instantiate(prototype, GetEnemyPoint().position, Quaternion.identity);
        }

        public Transform GetEnemyPoint()
        {
            int enemyIndex = Random.Range(0, _enemyPointList.Length - 1);

            return _enemyPointList[enemyIndex];
        }
    }
}
