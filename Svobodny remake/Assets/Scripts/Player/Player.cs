using System;
using UnityEngine;

namespace Player
{
    public class Player : Actor
    {
        [SerializeField] private int _noiseLevel;

        private IMovement _movement;
        private IState _idleState;
        private IState _sneakState;
        private IState _runState;
        private bool sneaking;

        private void Awake()
        {
            var rigidbody = GetComponent<Rigidbody2D>();
            input = new PlayerInput();
            
            _movement = new PlayerMovement(input, rigidbody, _speed, sneakSpeed, runSpeed);

            var mirrorWhenMovingLeft = GetComponent<MirrorWhenMovingLeft>();

            if (mirrorWhenMovingLeft != null)
            {
                mirrorWhenMovingLeft.Input = input;
            }


            _stateMachine = new StateMachine();

            _idleState = new IdleState(_noiseLevel, _animator, this, rigidbody, input, _movement);
            _sneakState = new SneakingState(_noiseLevel, _animator, this, rigidbody, input, _movement);
            _runState = new RunningState(_noiseLevel, _animator, this, rigidbody, input, _movement);
            
            SetTransitions();

            _stateMachine.SetState(_idleState);
        }

        private void Update()
        {
            _stateMachine.Update();
            
        }

        private void FixedUpdate()
        {
            _movement.FixedUpdate();
        }

        private void SetTransitions()
        {
            Func<bool> CrouchIsPressed() => () => input.IsSneakingPressed && !input.IsRunningPressed;
            Func<bool> RunIsPressed() => () => input.IsRunningPressed && !input.IsSneakingPressed;
            Func<bool> NothingIsPressed() => () => !input.IsRunningPressed && !input.IsSneakingPressed;
            
            _stateMachine.AddTransition(_idleState,_sneakState, CrouchIsPressed());
            _stateMachine.AddTransition(_idleState,_runState, RunIsPressed());
            _stateMachine.AddTransition(_runState,_sneakState,CrouchIsPressed());
            _stateMachine.AddTransition(_runState,_idleState,NothingIsPressed());
            _stateMachine.AddTransition(_sneakState,_runState,RunIsPressed());
            _stateMachine.AddTransition(_sneakState,_idleState,NothingIsPressed());
        }
    }
}