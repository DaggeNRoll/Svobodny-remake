using System;
using Player.WeaponSystem;
using UnityEngine;

namespace Player.ArmStaff
{
    public class Arm : MonoBehaviour
    {
        private PlayerWeaponSystem _weaponSystem;
        private SpriteRenderer _spriteRenderer;
        [SerializeField] private GameObject attackPointPrefab;
        private void OnEnable()
        {
            _weaponSystem ??= GetComponentInParent<PlayerWeaponSystem>();
            _spriteRenderer ??= GetComponent<SpriteRenderer>();

            
        }
        
        
    }
}