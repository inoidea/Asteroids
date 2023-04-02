using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class GameStarter : MonoBehaviour
    {
        [SerializeField] private Transform[] _enemyPointList;
        public static Stack<GameObject> bulletPool = new Stack<GameObject>();

        public void Start()
        {
            // Астероид.
            Enemy.CreateAsteroidEnemy(100, GetEnemyPoint().position);

            // Летающая тарелка.
            UFO original = (UFO) UFOFactory.CreateEnemy(100, GetEnemyPoint().position);
            original.SetAttackKind = new PowerfulAttack();

            //Enemy prototype = (Enemy)original.Clone();
            //prototype.DependencyInjectHealth(40);
            //Instantiate(prototype, GetEnemyPoint().position, Quaternion.identity);

            var enemy = new UFO(new PowerfulAttack(), null);
        }

        public Transform GetEnemyPoint()
        {
            int enemyIndex = Random.Range(0, _enemyPointList.Length - 1);

            return _enemyPointList[enemyIndex];
        }
    }
}
