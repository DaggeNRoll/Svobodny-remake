using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player.WeaponSystem
{
    public class AttackPoint : MonoBehaviour, IAttackPoint
    {
        [FormerlySerializedAs("_weaponGameObject")] [SerializeField] private GameObject weaponGameObject;
        
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
