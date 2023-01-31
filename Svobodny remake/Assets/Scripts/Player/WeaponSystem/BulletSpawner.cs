using System;
using UnityEngine;

namespace Player.WeaponSystem
{
    public class BulletSpawner : MonoBehaviour
    {
        private Weapon _parent;

        private void Awake()
        {
            _parent = GetComponentInParent<Weapon>();
        }
    }
}
