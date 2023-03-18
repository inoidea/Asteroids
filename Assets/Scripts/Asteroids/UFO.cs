using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Asteroids
{
    public sealed class UFO : Enemy
    {
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _force = 500;

        private void Start()
        {
            StartCoroutine("Move");
            StartCoroutine("AttackAll");
        }

        IEnumerator AttackAll()
        {
            while (Health > 0)
            {
                yield return new WaitForSeconds(2);
                Attack.Fire(_bullet, _barrel, _force);
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