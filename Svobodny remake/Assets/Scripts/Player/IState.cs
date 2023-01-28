using TMPro;
using UnityEngine;

namespace Player
{
    public interface IState
    {
        public void Update();
        public void FixedUpdate();
        public void OnEnter();
        public void OnExit();
        public string stateName { get; }
    }

    public abstract class InactiveState : IState
    {
        protected readonly Animator _animator;
        protected readonly Actor _actor;
        
        public virtual void Update()
        {
            throw new System.NotImplementedException();
        }

        public virtual void FixedUpdate()
        {
            throw new System.NotImplementedException();
        }

        public virtual void OnEnter()
        {
            throw new System.NotImplementedException();
        }

        public virtual void OnExit()
        {
            throw new System.NotImplementedException();
        }

        public string stateName { get; set; }
    }

    public class DeadState : InactiveState
    {
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

    public class HidingState : InactiveState
    {
        
    }

    public abstract class ActiveState : IState
    {

        protected int _noiseLevel;

        protected readonly Animator _animator;
        protected readonly Actor _actor;
        protected readonly Rigidbody2D _rigidbody;
        protected readonly int _horizontalSpeedHash = Animator.StringToHash("Horizontal speed");
        protected readonly int _verticalSpeedHash = Animator.StringToHash("Vertical speed");
        protected readonly int _sneakHash = Animator.StringToHash("Sneak");
        protected readonly int _runHash = Animator.StringToHash("Run");

        protected float _horizontalMove;
        protected float _verticalMove;

        protected IInput _input;
        protected IMovement _movement;
        
        

        protected ActiveState(int noiseLevel, Animator animator, Actor actor, Rigidbody2D rigidbody,
            IInput input, IMovement movement)
        {
            _noiseLevel = noiseLevel;
            _animator = animator;
            _actor = actor;
            _rigidbody=rigidbody;
            _input = input;
            _movement = movement;
        }
        
        public virtual void Update()
        {
            _input.HandleInput();
            _animator.SetFloat(_horizontalSpeedHash,_input.HorizontalInput);
            _animator.SetFloat(_verticalSpeedHash,_input.VerticalInput);
        }

        public virtual void FixedUpdate()
        {
            _movement.FixedUpdate();
        }

        public virtual void OnEnter()
        {
            
        }

        public virtual void OnExit()
        {
            
        }

        public string stateName { get; set; }
    }

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

    public class SneakingState : ActiveState
    {
        public SneakingState(int noiseLevel, Animator animator, Actor actor, Rigidbody2D rigidbody,
            IInput input, IMovement movement) 
            : base(noiseLevel, animator, actor, rigidbody, input, movement)
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

    public class WalkingState : ActiveState
    {
        public WalkingState(int noiseLevel, Animator animator, Actor actor, Rigidbody2D rigidbody,
            IInput input, IMovement movement) 
            : base(noiseLevel, animator, actor, rigidbody, input, movement)
        {
        }
    }

    public class RunningState : ActiveState
    {
        public RunningState(int noiseLevel, Animator animator, Actor actor, Rigidbody2D rigidbody,
            IInput input, IMovement movement)
            : base(noiseLevel, animator, actor, rigidbody, input, movement)
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