using States;
using UnityEngine;

public class IdleState : ActiveState
{
    public IdleState(int noiseLevel, Animator animator, Actor actor, Rigidbody2D rigidbody,
        IInput input, IMovement movement)
        : base(noiseLevel, animator, actor, rigidbody, input, movement)
    {
        stateName = "idle";
    }

    public override void OnEnter()
    {
        base.OnEnter();

        _movement.SetSpeedToDefaultSpeed();
    }
}