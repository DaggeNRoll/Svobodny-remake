using System;
using UnityEngine;

namespace Player
{
    public class Player : Actor
    {
        [SerializeField] private int _noiseLevel;
        private void Awake()
        {
            var rigidbody = GetComponent<Rigidbody2D>();

            _stateMachine = new StateMachine();

            var idle = new IdleState(_speed, _noiseLevel, _animator, this, rigidbody);
            
            _stateMachine.SetState(idle);

        }

        private void Update()
        {
            _stateMachine.Update();
        }

        private void FixedUpdate()
        {
            _stateMachine.FixedUpdate();
        }
    }
}