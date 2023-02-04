using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player.WeaponSystem
{
    public class BulletSpawner : MonoBehaviour, IAttackPoint
    {
        private Weapon _parent;
        [FormerlySerializedAs("_bulletPrefab")] [SerializeField] private GameObject bulletPrefab;
        [FormerlySerializedAs("_shotSpeed")] [SerializeField] private float shotSpeed;

        public Weapon Weapon { get; set; }

        private void OnEnable()
        {
            CreateBullet();
        }

        private void CreateBullet()
        {
            var bulletInstance = Instantiate(bulletPrefab);
            var bullet = bulletInstance.GetComponent<Bullet>();
            bullet.Weapon = Weapon;
            bulletInstance.GetComponent<Rigidbody2D>().AddForce(transform.right*shotSpeed, ForceMode2D.Impulse);
        }
    }
}
