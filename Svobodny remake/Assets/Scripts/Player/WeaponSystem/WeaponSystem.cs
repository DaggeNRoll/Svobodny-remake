using System;
using System.Collections.Generic;
using System.Linq;
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
            input.AttackEvent += StartAttack;

            currentWeapon = weapons.FirstOrDefault();
        
            _timeSinceLastAttack = float.MaxValue;
        }

        private void Update()
        {
            _timeSinceLastAttack += Time.deltaTime;
        }

        protected void StartAttack(object sender, EventArgs e)
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

        protected void FinishAttack(object sender, EventArgs e)
        {
            
        }
    }
}