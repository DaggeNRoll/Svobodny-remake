using UnityEngine;

namespace States.Player
{
    public class HidingState : InactiveState
    {
        public HidingState(Animator animator, Actor actor, IInput input) : base(animator, actor, input)
        {
        }
    }
}