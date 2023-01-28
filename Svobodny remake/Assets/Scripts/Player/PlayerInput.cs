﻿using UnityEngine;

namespace Player
{
    public class PlayerInput : IInput
    {
        public float HorizontalInput { get; set; }
        public float VerticalInput { get; set; }
        public bool IsSneakingPressed { get; set; }
        public bool IsRunningPressed { get; set; }


        public void HandleInput()
        {
            HorizontalInput = Input.GetAxisRaw("Horizontal");
            VerticalInput = Input.GetAxisRaw("Vertical");
            IsSneakingPressed = Input.GetAxisRaw("Crouch")>0.01f;
            IsRunningPressed = Input.GetAxisRaw("Run")>0.01f;
        }
        
    }
}