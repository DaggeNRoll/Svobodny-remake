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
        protected float _speed;
        protected int _noiseLevel;

        protected readonly Animator _animator;
        protected readonly Actor _actor;
        protected readonly Rigidbody2D _rigidbody;
        protected readonly int _horizontalSpeedHash = Animator.StringToHash("Horizontal speed");
        protected readonly int _verticalSpeedHash = Animator.StringToHash("Vertical speed");

        protected float _horizontalMove;
        protected float _verticalMove;
        

        protected ActiveState(float speed, int noiseLevel, Animator animator, Actor actor, Rigidbody2D rigidbody)
        {
            _speed = speed;
            _noiseLevel = noiseLevel;
            _animator = animator;
            _actor = actor;
            _rigidbody=rigidbody;
        }
        
        public virtual void Update()
        {
            _horizontalMove = Input.GetAxisRaw("Horizontal");
            _verticalMove = Input.GetAxisRaw("Vertical");
            _animator.SetFloat(_horizontalSpeedHash,_horizontalMove);
            _animator.SetFloat(_verticalSpeedHash,_verticalMove);
        }

        public virtual void FixedUpdate()
        {
            if (_horizontalMove is > 0.1f or < -0.1f)
            {
                _rigidbody.AddForce(new Vector2(_horizontalMove*_speed,0f), ForceMode2D.Impulse);
            }

            if (_verticalMove is > 0.1f or < -0.1f)
            {
                _rigidbody.AddForce(new Vector2(0f,_verticalMove*_speed), ForceMode2D.Impulse);
            }
        }

        public virtual void OnEnter()
        {
            
        }

        public virtual void OnExit()
        {
            
        }
    }

    public class IdleState : ActiveState
    {
        
        public IdleState(float speed, int noiseLevel, Animator animator, Actor actor, Rigidbody2D rigidbody)
            : base(speed, noiseLevel, animator, actor, rigidbody)
        {
            
        }
        
        
        
    }

    public class SneakingState : ActiveState
    {
        public SneakingState(float speed, int noiseLevel, Animator animator, Actor actor, Rigidbody2D rigidbody) 
            : base(speed, noiseLevel, animator, actor, rigidbody)
        {
        }
    }

    public class WalkingState : ActiveState
    {
        public WalkingState(float speed, int noiseLevel, Animator animator, Actor actor, Rigidbody2D rigidbody) 
            : base(speed, noiseLevel, animator, actor, rigidbody)
        {
        }
    }

    public class RunningState : ActiveState
    {
        public RunningState(float speed, int noiseLevel, Animator animator, Actor actor, Rigidbody2D rigidbody)
            : base(speed, noiseLevel, animator, actor, rigidbody)
        {
        }
    }
}