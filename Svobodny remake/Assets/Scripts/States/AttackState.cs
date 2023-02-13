using System;
using Player;
using Player.WeaponSystem;
using UnityEngine;

namespace States
{
    public class AttackState : InactiveState
    {
        private readonly int _attackHash = Animator.StringToHash("Attack");
        private readonly int _horizontalMousePositionHash = Animator.StringToHash("Horizontal mouse position");
        private readonly int _verticalMousePositionHash = Animator.StringToHash("Vertical mouse position");
        private GameObject _arm;
        private WeaponSystem _weaponSystem;
        private PlayerInput _playerInput;
        

        public AttackState(Animator animator, Actor actor, IInput input, WeaponSystem weaponSystem,
            Rigidbody2D rigidbody2D, IMovement movement) : base(animator, actor, input, rigidbody2D, movement)
        {
            _weaponSystem = weaponSystem;
            stateName = "attack";
        }

        public override void OnEnter()
        {
            base.OnEnter();
            try
            {
                _playerInput = _input as PlayerInput;
                _animator.SetFloat(_horizontalMousePositionHash,_playerInput.MousePosition.x);
                _animator.SetFloat(_verticalMousePositionHash, _playerInput.MousePosition.y);
            }
            catch (InvalidCastException)
            {
                throw new InvalidCastException("Класс Input не является PLayerInput");
            }
            
            
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