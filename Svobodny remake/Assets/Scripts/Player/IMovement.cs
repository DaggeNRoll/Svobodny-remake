using UnityEngine;

public interface IMovement
{
    public IInput Input { get; set; }
    public Rigidbody2D Rigidbody { get; set; }
    public float Speed { get; }
    public float SneakSpeed { get; }
    public float RunSpeed { get; }
    public float DefaultSpeed { get; }  

    void FixedUpdate();

    void SetSpeedToSneakSpeed();
    void SetSpeedToRunSpeed();
    void SetSpeedToDefaultSpeed();
    void StopActor();
}