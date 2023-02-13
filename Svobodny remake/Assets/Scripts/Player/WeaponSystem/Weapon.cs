using UnityEngine;

namespace Player.WeaponSystem
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected WeaponObject weaponObject;

        [SerializeField] protected IAttackPoint attackPoint;

        public WeaponObject WeaponObject => weaponObject;
        
        public abstract void StartAttack();
        public abstract void FinishAttack();

        public abstract void OnEquip();

        public abstract void OnUnequip();

    }
}