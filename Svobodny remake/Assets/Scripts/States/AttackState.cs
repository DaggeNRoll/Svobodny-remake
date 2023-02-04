using System;
using UnityEngine;

namespace States
{
    public class AttackState : InactiveState
    {
        private readonly int _attackHash = Animator.StringToHash("Attack");

        public AttackState(Animator animator, Actor actor, IInput input) : base(animator, actor, input)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            _animator.SetTrigger(_attackHash);
        }

        public override void OnExit()
        {
            base.OnExit();
            
        }
    }
}