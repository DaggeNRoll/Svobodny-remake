using Player;
using Player.WeaponSystem;
using UnityEngine;

namespace States
{
    public class IdleState : ActiveState
    {
        public IdleState(int noiseLevel, Animator animator, Actor actor, Rigidbody2D rigidbody,
            IInput input, IMovement movement, WeaponSystem weaponSystem)
            : base(noiseLevel, animator, actor, rigidbody, input, movement, weaponSystem)
        {
            stateName = "idle";
        }

        public override void OnEnter()
        {
            base.OnEnter();

            _movement.SetSpeedToDefaultSpeed();
        }
    }
}