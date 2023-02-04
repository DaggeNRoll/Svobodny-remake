using System;
using UnityEngine;

namespace Player.WeaponSystem
{
    public class AttackPoint : MonoBehaviour, IAttackPoint
    {
        [SerializeField] private GameObject _weaponGameObject;
        
        public Weapon Weapon { get; set; }
        private void Awake()
        {
            
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            var target = col.gameObject.GetComponent<IDamageable>();
            
            target?.ReduceHealth(Weapon.Damage);
        }

    }
    
    
}
