using System;
using UnityEngine;

namespace Player
{
    public abstract class Actor : MonoBehaviour
    {
        protected StateMachine _stateMachine;
        [SerializeField] protected Animator _animator;
        [SerializeField] protected float _speed;
        [SerializeField] protected float sneakSpeed;
        [SerializeField] protected float runSpeed;
        protected IInput input;



    }
}