using System;
using Player.WeaponSystem;
using Player.WeaponSystem.Weapons;
using UnityEngine;

namespace States
{
    public abstract class ActiveState : IState
    {
        protected int _noiseLevel;

        protected readonly Animator _animator;
        protected readonly Actor _actor;
        protected readonly Rigidbody2D _rigidbody;
        protected readonly int _horizontalSpeedHash = Animator.StringToHash("Horizontal speed");
        protected readonly int _verticalSpeedHash = Animator.StringToHash("Vertical speed");
        protected readonly int _sneakHash = Animator.StringToHash("Sneak");
        protected readonly int _runHash = Animator.StringToHash("Run");

        protected float _horizontalMove;
        protected float _verticalMove;

        protected IInput _input;
        protected IMovement _movement;
        protected WeaponSystem _weaponSystem;


        protected ActiveState(int noiseLevel, Animator animator, Actor actor, Rigidbody2D rigidbody,
            IInput input, IMovement movement, WeaponSystem weaponSystem)
        {
            _noiseLevel = noiseLevel;
            _animator = animator;
            _actor = actor;
            _rigidbody = rigidbody;
            _input = input;
            _movement = movement;
            _weaponSystem = weaponSystem;
            weaponSystem.WeaponEquipped += ChangeWeaponAnimation;
        }

        public virtual void Update()
        {
            _input.HandleInput();
            _animator.SetFloat(_horizontalSpeedHash, _input.HorizontalInput);
            _animator.SetFloat(_verticalSpeedHash, _input.VerticalInput);
            //Debug.Log(stateName);
        }

        public virtual void FixedUpdate()
        {
            _movement.FixedUpdate();
        }

        public virtual void OnEnter()
        {
        }

        public virtual void OnExit()
        {
        }

        protected virtual void ChangeWeaponAnimation(object sender, WeaponSystem.EquippedWeaponArgs equippedWeaponArgs)
        {
            _animator.SetTrigger(equippedWeaponArgs.WeaponName);
        }

        public string stateName { get; protected set; }
    }
}