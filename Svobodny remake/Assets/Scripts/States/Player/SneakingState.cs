using Player;
using Player.WeaponSystem;
using UnityEngine;

namespace States.Player
{
    public class SneakingState : ActiveState
    {
        public SneakingState(int noiseLevel, Animator animator, Actor actor, Rigidbody2D rigidbody,
            IInput input, IMovement movement, WeaponSystem weaponSystem)
            : base(noiseLevel, animator, actor, rigidbody, input, movement, weaponSystem)
        {
            stateName = "sneaking";
        }

        public override void OnEnter()
        {
            base.OnEnter();

            _animator.SetBool(_sneakHash, true);
            _movement.SetSpeedToSneakSpeed();
        }

        public override void OnExit()
        {
            base.OnExit();

            _animator.SetBool(_sneakHash, false);
        }
    }
}