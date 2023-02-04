using Player.WeaponSystem;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "knife", menuName = "knife", order = 0)]
public class Knife : Weapon
{
    public override void StartAttack()
    {
        attackPointPrefab.SetActive(true);
        attackPointPrefab.GetComponent<IAttackPoint>().Weapon = this;
    }

    public override void FinishAttack()
    {
        attackPointPrefab.SetActive(false);
    }
}
