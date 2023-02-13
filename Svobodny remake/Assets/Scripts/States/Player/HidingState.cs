using Player;
using UnityEngine;

namespace States.Player
{
    public class HidingState : InactiveState
    {
        public HidingState(Animator animator, Actor actor, IInput input, Rigidbody2D rigidbody2D, IMovement movement)
            : base(animator, actor, input, rigidbody2D, movement)
        {
        }
    }
}