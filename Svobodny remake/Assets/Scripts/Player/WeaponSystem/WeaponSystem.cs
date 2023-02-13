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
        public event EventHandler AttackHasBeenFinished;
        public event EventHandler AttackHasBeenStarted;
        public event EventHandler ActorIsAiming;

        public Weapon CurrentWeapon => currentWeapon;

        public class EquippedWeaponArgs : EventArgs
        {
            public string WeaponName { get; set; }
        }

        public virtual void EquipWeapon(Weapon weapon)
        {
            // ReSharper disable once Unity.NoNullPropagation
            currentWeapon?.OnUnequip();
            currentWeapon = weapon;
            currentWeapon.OnEquip();
            WeaponEquipped?.Invoke(this, 
                new EquippedWeaponArgs {WeaponName = currentWeapon.WeaponObject.weaponName});
            
        }

        public virtual void AddWeapon(Weapon weapon)
        {
            if(weapons.Contains(weapon))
                return;
        
            weapons.Add(weapon);
        }
        

        protected virtual void Start()
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

        public void PerformAttack(object sender, EventArgs eventArgs)
        {
            StartAttack();
            StartCoroutine(WaitForAttackAnimationCoroutine(attackAnimationDuration));
            
        }

        protected IEnumerator WaitForAttackAnimationCoroutine(float animationDurationInSeconds)
        {
            yield return new WaitForSeconds(animationDurationInSeconds);
            FinishAttack();
        }

        protected void StartAttack()
        {
            if(!weapons.Any())
                return;
        
            if(currentWeapon==null)
                return;
        
            if(_timeSinceLastAttack<currentWeapon.WeaponObject.AttackRate)
                return;
            
            //Debug.LogWarning("start");
            
            AttackHasBeenStarted?.Invoke(this,EventArgs.Empty);
            currentWeapon.StartAttack();
            _timeSinceLastAttack = 0f;
        }

        protected void FinishAttack()
        {
            if (currentWeapon == null)
                return;
            
            //Debug.LogWarning("finish");
            
            currentWeapon.FinishAttack();
            _timeSinceLastAttack = float.MaxValue;
            AttackHasBeenFinished?.Invoke(this, EventArgs.Empty);
        }
    }
}