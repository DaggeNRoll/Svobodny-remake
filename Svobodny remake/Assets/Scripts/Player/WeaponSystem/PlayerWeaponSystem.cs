using System;
using UnityEngine;

namespace Player.WeaponSystem
{
    public class PlayerWeaponSystem : WeaponSystem
    {
        [SerializeField] private GameObject arm;
        [SerializeField] private Animator armAnimator;
        
        public override void EquipWeapon(Weapon weapon)
        {
            base.EquipWeapon(currentWeapon);
        }

        protected override void Start()
        {
            base.Start();
            EquipWeapon(currentWeapon);
            
        }

        private void Aim()
        {
            //arm.SetActive(true);
        }
    }
}