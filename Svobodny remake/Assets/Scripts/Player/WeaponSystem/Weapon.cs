﻿using UnityEngine;

namespace Player.WeaponSystem
{
    [CreateAssetMenu(menuName = "Weapons")]
    public abstract class Weapon : ScriptableObject
    {
        [SerializeField] protected Sprite sprite;
        [SerializeField] protected int damage;
        [SerializeField] protected GameObject attackPointPrefab;
        [SerializeField] protected int attackRate;

        public int Damage => damage;


        public int AttackRate { get=>attackRate; protected set => attackRate=value; }

        public abstract void Attack();
    }
}