using Player;
using UnityEngine;

namespace States
{
    public class DeadState : InactiveState
    {
        public DeadState(Animator animator, Actor actor, IInput input, Rigidbody2D rigidbody2D, IMovement movement)
            : base(animator, actor, input, rigidbody2D, movement)
        {
        }
        
        public override void OnEnter()
        {
            base.OnEnter();
        }

        public override void Update()
        {
            base.Update();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
        }

        public override void OnExit()
        {
            base.OnExit();
        }

        
    }
}