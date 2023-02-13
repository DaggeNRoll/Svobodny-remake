using System;
using UnityEngine;

namespace Player.WeaponSystem
{
    public class PlayerWeaponSystem : WeaponSystem
    {
        [SerializeField] private GameObject arm;
        [SerializeField] private Animator armAnimator;
        public PlayerInput PlayerInput { get; private set; }

        public override void EquipWeapon(Weapon weapon)
        {
            base.EquipWeapon(currentWeapon);
        }

        protected override void Start()
        {
            base.Start();
            try
            {
                PlayerInput = input as PlayerInput;
            }
            catch (InvalidCastException)
            {
                throw new InvalidCastException("Класс должен быть типа PlayerInput");
            }
            
            EquipWeapon(currentWeapon);
            
        }

        private void Aim()
        {
            //arm.SetActive(true);
        }
    }
}