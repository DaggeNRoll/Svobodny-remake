using System;
using UnityEngine;

namespace Player.WeaponSystem.Weapons
{
    public class Knife : Weapon
    {
        [SerializeField] private Collider2D attackCollider;
        public override void StartAttack()
        {
            attackCollider.enabled = true;
        }

        public override void FinishAttack()
        {
            attackCollider.enabled = false;
        }

        public override void OnEquip()
        {
            
        }

        public override void OnUnequip()
        {
            
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if(col.gameObject.CompareTag("Player"))
                return;
            
            var target = col.gameObject.GetComponent<IDamageable>();
            
            target?.ReduceHealth(weaponObject.Damage);
        }
    }
}