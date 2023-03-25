using System;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public abstract class Enemy : MonoBehaviour, IHealth, ICloneable
    {
        [SerializeField] private float _hp;

        public static IEnemyFactory Factory;

        public float Health
        {
            get { return _hp; }
            set { _hp = value; }
        }

        public static Asteroid CreateAsteroidEnemy(float hp, Vector3 enemyPoint)
        {
            var enemy = Instantiate(Resources.Load<Asteroid>("Enemy/Asteroid"), enemyPoint, Quaternion.identity);
            enemy.Health = hp;

            return enemy;
        }

        public void DependencyInjectHealth(float hp)
        {
            Health = hp;
        }

        public object Clone() { 
            return MemberwiseClone();
        }
    }
}
