using System;
using Player.WeaponSystem;
using States;
using States.Player;
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
        private WeaponSystem.WeaponSystem _weaponSystem;
        private bool sneaking;
        

        private void Awake()
        {
            var rb = GetComponent<Rigidbody2D>();
            input = new PlayerInput();
            
            _movement = new PlayerMovement(input, rb, _speed, sneakSpeed, runSpeed);
            _weaponSystem = gameObject.GetComponent<PlayerWeaponSystem>();

            var mirrorWhenMovingLeft = GetComponent<MirrorWhenMovingLeft>();

            if (mirrorWhenMovingLeft != null)
            {
                mirrorWhenMovingLeft.Input = input;
            }


            _stateMachine = new StateMachine();

            _idleState = new IdleState(_noiseLevel, _animator, this, rb, input, _movement, _weaponSystem);
            _sneakState = new SneakingState(_noiseLevel, _animator, this, rb, input, _movement, _weaponSystem);
            _runState = new RunningState(_noiseLevel, _animator, this, rb, input, _movement, _weaponSystem);
            
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


        public override void StopAttack(object sender, EventArgs e)
        {
             
        }
    }
}