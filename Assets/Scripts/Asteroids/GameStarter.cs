using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class GameStarter : MonoBehaviour
    {
        [SerializeField] private Transform[] _enemyPointList;

        private void Start()
        {
            Enemy.CreateAsteroidEnemy(100, GetEnemyPoint().position);

            UFOFactory.CreateEnemy(100, GetEnemyPoint().position);
        }

        public Transform GetEnemyPoint()
        {
            int enemyIndex = Random.Range(0, _enemyPointList.Length - 1);

            return _enemyPointList[enemyIndex];
        }
    }
}
