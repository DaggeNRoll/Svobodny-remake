using System;
using UnityEngine;

namespace Player
{
    public class PlayerInput : IInput, IShoot
    {
        public float HorizontalInput { get; set; }
        public float VerticalInput { get; set; }
        public bool IsSneakingPressed { get; set; }
        public bool IsRunningPressed { get; set; }
        public event EventHandler AttackEvent;


        public bool IsAttackPressed { get; private set; }

        private Camera _mainCamera;

        public PlayerInput(Camera mainCamera)
        {
            _mainCamera = mainCamera;
        }
        
        

        public void HandleInput()
        {
            HorizontalInput = Input.GetAxisRaw("Horizontal");
            VerticalInput = Input.GetAxisRaw("Vertical");
            IsSneakingPressed = Input.GetAxisRaw("Crouch")>0.01f;
            IsRunningPressed = Input.GetAxisRaw("Run")>0.01f;
            var mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            MousePosition = new Vector3(Mathf.Clamp(mousePosition.x,-1f,1f),
                Mathf.Clamp(mousePosition.y,-1,1));
            
            if (Input.GetButtonDown("Fire1"))
            {
                AttackEvent?.Invoke(this, EventArgs.Empty);
                IsAttackPressed = true;
            }
            else
            {
                IsAttackPressed = false;
            }
        }

        public Vector3 MousePosition { get; private set; }
    }
}