using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Asteroids
{
    public sealed class UFO : Enemy
    {
        [SerializeField] private GameObject _bullet;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _force = 500;

        private IAttack _attack;
        private readonly IMove _move;

        public IAttack SetAttackKind
        {
            set { _attack = value; }
        }

        public UFO(IAttack attack, IMove move): base(attack, move)
        {
            _attack = attack;
            _move = move;
        }

        private void Start()
        {
            StartCoroutine("Move");
            StartCoroutine("AttackAll");
        }

        public override void Attack()
        {
            _attack.Attack(_bullet, _barrel, _force);
        }

        IEnumerator AttackAll()
        {
            while (Health > 0)
            {
                yield return new WaitForSeconds(2);
                Attack();
            }
        }

        IEnumerator Move()
        {
            while (Health > 0)
            {
                yield return new WaitForSeconds(2);
                transform.Translate(1, 0, 0);
                yield return new WaitForSeconds(2);
                transform.Translate(-1, 0, 0);
            }
        }
    }
}