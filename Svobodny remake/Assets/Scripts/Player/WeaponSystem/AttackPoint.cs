using System;
using UnityEngine;

namespace Player.WeaponSystem
{
    public class AttackPoint : MonoBehaviour
    {
        private Weapon _parent;
        private void Awake()
        {
            _parent = GetComponentInParent<Weapon>();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            var target = col.gameObject.GetComponent<IDamageable>();
            
            target?.ReduceHealth(_parent.Damage);
        }
    }
    
    
}
