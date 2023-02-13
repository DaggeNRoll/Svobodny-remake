using System;

namespace Player
{
    public interface IInput
    {
        public float HorizontalInput { get; set; }
        public float VerticalInput { get; set; }
        public bool IsSneakingPressed { get; set; }
        public bool IsRunningPressed { get; set; }

        public event EventHandler AttackEvent;
        public bool IsAttackPressed { get; }
        void HandleInput();
    }
}