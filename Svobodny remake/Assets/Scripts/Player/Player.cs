using System;
using Newtonsoft.Json.Bson;
using Player.ArmStaff;
using Player.WeaponSystem;
using States;
using States.Player;
using UnityEngine;
using UnityEngine.UIElements;


namespace Player
{
    public class Player : Actor
    {
        [SerializeField] private int _noiseLevel;

        private IMovement _movement;
        private IState _idleState;
        private IState _sneakState;
        private IState _runState;
        private IState _attackState;
        private WeaponSystem.WeaponSystem _weaponSystem;
        private bool sneaking;
        private Arm arm;
        [SerializeField] private bool _attackIsFinished;
        [SerializeField] private Camera _mainCamera;

        public PlayerInput PlayerInput => input as PlayerInput;


        private void Awake()
        {
            var rb = GetComponent<Rigidbody2D>();
            input = new PlayerInput(_mainCamera);
            
            _movement = new PlayerMovement(input, rb, _speed, sneakSpeed, runSpeed);
            _weaponSystem = gameObject.GetComponent<PlayerWeaponSystem>();

            _weaponSystem.AttackHasBeenFinished += FinishAttackHandler;

            var mirrorWhenMovingLeft = GetComponent<MirrorWhenMovingLeft>();

            if (mirrorWhenMovingLeft != null)
            {
                mirrorWhenMovingLeft.Input = input;
            }


            _stateMachine = new StateMachine();

            _idleState = new IdleState(_noiseLevel, _animator, this, rb, input, _movement, _weaponSystem);
            _sneakState = new SneakingState(_noiseLevel, _animator, this, rb, input, _movement, _weaponSystem);
            _runState = new RunningState(_noiseLevel, _animator, this, rb, input, _movement, _weaponSystem);
            _attackState = new AttackState(_animator, this, input, _weaponSystem, rb, _movement);
            
            SetTransitions();

            _stateMachine.SetState(_idleState);
        }

        private void Start()
        {
            _attackIsFinished = true;
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
            Func<bool> AttackIsPressed() => () =>
            {
                if (!input.IsAttackPressed || !_attackIsFinished) return false;
                
                _attackIsFinished = false;
                return true;

            };

            Func<bool> AttackIsFinished() => () => _attackIsFinished;

            _stateMachine.AddTransition(_idleState,_sneakState, CrouchIsPressed());
            _stateMachine.AddTransition(_idleState,_runState, RunIsPressed());
            _stateMachine.AddTransition(_runState,_sneakState,CrouchIsPressed());
            _stateMachine.AddTransition(_runState,_idleState,NothingIsPressed());
            _stateMachine.AddTransition(_sneakState,_runState,RunIsPressed());
            _stateMachine.AddTransition(_sneakState, _idleState, NothingIsPressed()); 
            _stateMachine.AddTransition(_idleState, _attackState, AttackIsPressed());
            _stateMachine.AddTransition(_sneakState, _attackState, AttackIsPressed());
            _stateMachine.AddTransition(_attackState,_idleState,AttackIsFinished());
        }


        public override void StopAttack(object sender, EventArgs e)
        {
             
        }

        private void FinishAttackHandler(object sender, EventArgs eventArgs)
        {
            _attackIsFinished = true;
           // Debug.LogWarning(_attackIsFinished);
        }
    }
}