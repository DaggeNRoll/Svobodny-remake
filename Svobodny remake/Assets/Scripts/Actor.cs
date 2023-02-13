using System;
using Player;
using UnityEngine;


public abstract class Actor : MonoBehaviour, IDamageable
{
    protected StateMachine _stateMachine;
    [SerializeField] protected Animator _animator;
    [SerializeField] protected float _speed;
    [SerializeField] protected float sneakSpeed;
    [SerializeField] protected float runSpeed;
    protected IInput input;
    [SerializeField] private int _health;

    public event EventHandler AttackAnimationHasStopped;

    public int Health
    {
        get => _health;
        private set => _health = value;
    }

    public IInput Input => input;

    public void ReduceHealth(int amount)
    {
        Health -= amount;
        if (Health <= 0)
        {
            Die();
        }
    }

    protected void Die()
    {
        //TODO
    }

    public abstract void StopAttack(object sender, EventArgs e);
}