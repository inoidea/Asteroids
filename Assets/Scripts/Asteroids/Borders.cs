using Asteroids;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Asteroids
{
    internal sealed class Borders : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            var unit = other.gameObject.GetComponent<IHealth>();

            if (unit == null)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
