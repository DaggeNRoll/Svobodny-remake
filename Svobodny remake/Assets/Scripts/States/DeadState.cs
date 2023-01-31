using UnityEngine;

namespace States
{
    public class DeadState : InactiveState
    {
        public DeadState(Animator animator, Actor actor, IInput input) : base(animator, actor, input)
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