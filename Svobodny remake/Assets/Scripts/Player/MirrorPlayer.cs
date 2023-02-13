using System;
using UnityEngine;

namespace Player
{
    public class MirrorPlayer : MonoBehaviour
    {
        [SerializeField]private Player _player;

        private void Update()
        {
            
            transform.localRotation=Quaternion.Euler(0, _player.PlayerInput.MousePosition.x < 0f? 180 : 0,0);
        }
    }
}