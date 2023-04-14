using Asteroids.Observer;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public abstract class Enemy : MonoBehaviour, IHealth, ICloneable, IHit
    {
        [SerializeField] private float _hp;

        public static IEnemyFactory Factory;
        private readonly IAttack _attack;
        private readonly IMove _move;

        public event Action<float> OnHitChange = delegate (float f) { };

        public float Health
        {
            get { return _hp; }
            set { _hp = value; }
        }

        public Enemy(IAttack attack, IMove move)
        {
            _attack = attack;
            _move = move;
        }

        public void Hit(float damage)
        {
            OnHitChange.Invoke(damage);
        }

        public abstract void Attack();

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
