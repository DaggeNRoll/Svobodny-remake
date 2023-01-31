using System;
using System.Collections.Generic;
using System.Linq;
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

        public abstract void EquipWeapon(Weapon weapon, Actor actor);

        public virtual void AddWeapon(Weapon weapon)
        {
            if(weapons.Contains(weapon))
                return;
        
            weapons.Add(weapon);
        }

        public void Start()
        {
            input = handler.Input;
            input.AttackEvent += Attack;

            currentWeapon = weapons.FirstOrDefault();
        
            _timeSinceLastAttack = float.MaxValue;
        }

        protected void Attack(object sender, EventArgs e)
        {
            if(!weapons.Any())
                return;
        
            if(currentWeapon==null)
                return;
        
            if(_timeSinceLastAttack<currentWeapon.AttackRate)
                return;
        
            currentWeapon.Attack();
        }
    }
}