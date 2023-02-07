using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Player.WeaponSystem
{
    public class Bullet : MonoBehaviour
    {
        public WeaponObject Weapon { get; set; }

        [SerializeField] private float autoDestroyTime;
        private float _timeSinceShot;

        private void Start()
        {
            _timeSinceShot = 0f;
        }
        
        private void Update()
        {
            _timeSinceShot += Time.deltaTime;

            if (_timeSinceShot >= autoDestroyTime)
                Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            var target = col.gameObject.GetComponent<IDamageable>();

            target?.ReduceHealth(Weapon.Damage);
        }
    }
}