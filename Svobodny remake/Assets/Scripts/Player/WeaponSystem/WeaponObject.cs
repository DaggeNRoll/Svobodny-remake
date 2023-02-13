using UnityEngine;

namespace Player.WeaponSystem
{
    [CreateAssetMenu(menuName = "Weapons")]
    public abstract class WeaponObject : ScriptableObject
    {
        [SerializeField] protected Sprite sprite;
        [SerializeField] protected int damage;
        [SerializeField] protected GameObject attackPointPrefab;
        [SerializeField] protected int attackRate;
        [SerializeField] public string weaponName;

        public int Damage => damage;
        public Sprite Sprite => sprite;


        public int AttackRate { get=>attackRate; protected set => attackRate=value; }

        /*public abstract void StartAttack();
        public abstract void FinishAttack();*/
    }
}