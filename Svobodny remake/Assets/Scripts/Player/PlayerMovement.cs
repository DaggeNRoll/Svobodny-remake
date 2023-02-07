using UnityEngine;

namespace Player
{
    public class PlayerMovement : IMovement
    {
        public PlayerMovement(IInput input, Rigidbody2D rigidbody2D, float defaultSpeed, float sneakSpeed, float runSpeed)
        {
            Input = input;
            Rigidbody = rigidbody2D;
            DefaultSpeed = defaultSpeed;
            SneakSpeed = sneakSpeed;
            RunSpeed = runSpeed;
            SetSpeedToDefaultSpeed();
        }

        public IInput Input { get; set; }
        public Rigidbody2D Rigidbody { get; set; }
        public float Speed { get; private set; }
        public float SneakSpeed { get; }
        public float RunSpeed { get; }
        public float DefaultSpeed { get; }


        public void FixedUpdate()
        {
            if (Input.HorizontalInput is > 0.1f or < -0.1f)
            {
                Rigidbody.AddForce(new Vector2(Input.HorizontalInput*Speed,0f), ForceMode2D.Impulse);
            }

            if (Input.VerticalInput is > 0.1f or < -0.1f)
            {
                Rigidbody.AddForce(new Vector2(0f,Input.VerticalInput*Speed), ForceMode2D.Impulse);
            }
        }

        public void SetSpeedToSneakSpeed()
        {
            Speed = SneakSpeed;
            
        }

        public void SetSpeedToRunSpeed()
        {
            Speed = RunSpeed;
        }

        public void SetSpeedToDefaultSpeed()
        {
            Speed = DefaultSpeed;
        }

        public void StopActor()
        {
            Speed = 0;
        }
    }
}
