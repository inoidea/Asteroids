using System.Numerics;
using UnityEngine;

namespace Asteroids
{
    public sealed class Asteroid : Enemy
    {
        private readonly IAttack _attack;
        private readonly IMove _move;

        public Asteroid(IAttack attack, IMove move) : base(attack, move)
        {
            _attack = attack;
            _move = move;
        }

        public override void Attack()
        {
            _attack.Attack();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Damage.GetDamage(other.gameObject, 10);
        }
    }
}