using Player;
using Player.WeaponSystem;
using UnityEngine;

namespace States.Player
{
    public class RunningState : ActiveState
    {
        public RunningState(int noiseLevel, Animator animator, Actor actor, Rigidbody2D rigidbody,
            IInput input, IMovement movement, WeaponSystem weaponSystem)
            : base(noiseLevel, animator, actor, rigidbody, input, movement, weaponSystem)
        {
            stateName = "running";
        }

        public override void OnEnter()
        {
            base.OnEnter();

            _animator.SetBool(_runHash, true);
            _movement.SetSpeedToRunSpeed();
        }

        public override void OnExit()
        {
            base.OnExit();

            _animator.SetBool(_runHash, false);
        }
    }
}