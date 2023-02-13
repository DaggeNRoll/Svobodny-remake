using Player;
using UnityEngine;

namespace States
{
    public abstract class InactiveState : IState
    {
        protected readonly Animator _animator;
        protected readonly Actor _actor;
        protected IInput _input;
        protected Rigidbody2D _rigidbody2D;
        protected IMovement _movement;


        protected InactiveState(Animator animator, Actor actor, IInput input, Rigidbody2D rigidbody2D, IMovement movement)
        {
            _animator = animator;
            _actor = actor;
            _input = input;
            _rigidbody2D = rigidbody2D;
            _movement = movement;
        }

        public virtual void Update()
        {
           // Debug.Log(stateName);
        }

        public virtual void FixedUpdate()
        {
            
        }

        public virtual void OnEnter()
        {
            _movement.StopActor();
        }

        public virtual void OnExit()
        {
            
        }

        public string stateName { get; set; }
    }
}