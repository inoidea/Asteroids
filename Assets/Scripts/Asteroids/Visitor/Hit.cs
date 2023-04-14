﻿using UnityEngine;

namespace Asteroids.Visitor
{
    public abstract class Hit : MonoBehaviour
    {
        public float Health;
        public TextMesh TextMesh;
        public abstract void Activate(IDealingDamage value, float damage);
    }
}
