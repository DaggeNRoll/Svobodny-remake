using System;
using UnityEngine;

namespace Player.WeaponSystem
{
    public class BulletSpawner : MonoBehaviour, IAttackPoint
    {
        private Weapon _parent;
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private float _shotSpeed;

        public Weapon Weapon { get; set; }

        private void OnEnable()
        {
            CreateBullet();
        }

        private void CreateBullet()
        {
            var bulletInstance = Instantiate(_bulletPrefab);
            var bullet = bulletInstance.GetComponent<Bullet>();
            bullet.Weapon = Weapon;
            bulletInstance.GetComponent<Rigidbody2D>().AddForce(transform.right*_shotSpeed, ForceMode2D.Impulse);
        }
    }
}
