
    public interface IInput
    {
        public float HorizontalInput { get; set; }
        public float VerticalInput { get; set; }
        public bool IsSneakingPressed { get; set; }
        public bool IsRunningPressed { get; set; }
        void HandleInput();
        
        

    }

