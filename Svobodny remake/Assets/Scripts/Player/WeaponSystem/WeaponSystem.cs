using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace Player.WeaponSystem
{
    public abstract class WeaponSystem : MonoBehaviour
    {
        [SerializeField] protected List<Weapon> weapons;
        [SerializeField] protected Weapon currentWeapon;
        private float _timeSinceLastAttack;
        [SerializeField] protected Actor handler;
        protected IInput input;
        [SerializeField] protected float attackAnimationDuration;
        public event EventHandler<EquippedWeaponArgs> WeaponEquipped;

        public class EquippedWeaponArgs : EventArgs
        {
            public string WeaponName { get; set; }
        }

        public virtual void EquipWeapon(Weapon weapon, Actor actor)
        {
            currentWeapon = weapon;
            WeaponEquipped?.Invoke(this, new EquippedWeaponArgs {WeaponName = weapon.weaponName});
        }

        public virtual void AddWeapon(Weapon weapon)
        {
            if(weapons.Contains(weapon))
                return;
        
            weapons.Add(weapon);
        }

        public void Start()
        {
            input = handler.Input;
            input.AttackEvent += PerformAttack;

            currentWeapon = weapons.FirstOrDefault();
        
            _timeSinceLastAttack = float.MaxValue;
        }

        private void Update()
        {
            _timeSinceLastAttack += Time.deltaTime;
        }

        protected void PerformAttack(object sender, EventArgs eventArgs)
        {
            StartAttack();
            StartCoroutine(WaitForAttackAnimationCoroutine(attackAnimationDuration));
            FinishAttack();
        }

        protected IEnumerator WaitForAttackAnimationCoroutine(float animationDurationInSeconds)
        {
            yield return new WaitForSeconds(animationDurationInSeconds);
        }

        protected void StartAttack()
        {
            if(!weapons.Any())
                return;
        
            if(currentWeapon==null)
                return;
        
            if(_timeSinceLastAttack<currentWeapon.AttackRate)
                return;
        
            currentWeapon.StartAttack();
            _timeSinceLastAttack = 0f;
        }

        protected void FinishAttack()
        {
            if (currentWeapon == null)
                return;
            
            currentWeapon.FinishAttack();
            _timeSinceLastAttack = float.MaxValue;
        }
    }
}