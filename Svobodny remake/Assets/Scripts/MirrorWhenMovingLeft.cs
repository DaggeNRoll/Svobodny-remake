using System;
using Player;
using UnityEngine;

public class MirrorWhenMovingLeft : MonoBehaviour
{
    public IInput Input { get; set; }
    private void Update()
    {
        transform.localRotation = Quaternion.Euler(0, Input.HorizontalInput < 0f ? 180 : 0, 0);
    }
}
