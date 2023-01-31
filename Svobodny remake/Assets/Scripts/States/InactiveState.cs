using UnityEngine;

namespace States
{
    public abstract class InactiveState : IState
    {
        protected readonly Animator _animator;
        protected readonly Actor _actor;
        protected IInput _input;


        protected InactiveState(Animator animator, Actor actor, IInput input)
        {
            _animator = animator;
            _actor = actor;
            _input = input;
        }

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
}