using Player.WeaponSystem;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "knife", menuName = "knife", order = 0)]
public class Knife : Weapon
{
    public override void Attack()
    {
        attackPointPrefab.SetActive(true);
        
    }
}
