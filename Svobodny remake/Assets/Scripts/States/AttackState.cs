using System;
using Player.WeaponSystem;
using UnityEngine;

namespace States
{
    public class AttackState : InactiveState
    {
        private readonly int _attackHash = Animator.StringToHash("Attack");
        private GameObject _arm;
        private WeaponSystem _weaponSystem;

        public AttackState(Animator animator, Actor actor, IInput input, WeaponSystem weaponSystem,
            Rigidbody2D rigidbody2D, IMovement movement) : base(animator, actor, input, rigidbody2D, movement)
        {
            _weaponSystem = weaponSystem;
            stateName = "attack";
        }

        public override void OnEnter()
        {
            base.OnEnter();
            //_arm.SetActive(true);
            _animator.SetTrigger(_attackHash);
            
            
        }

        public override void Update()
        {
            base.Update();
        }

        public override void OnExit()
        {
            base.OnExit();
            
        }
    }
}