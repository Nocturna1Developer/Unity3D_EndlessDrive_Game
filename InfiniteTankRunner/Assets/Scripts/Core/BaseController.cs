using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    // The speed moving left and right and forward respectivly
    public Vector3 speed;
    public float x_Speed = 8f, z_Speed = 15f;
    public float accelerated = 15f, deccelerated = 15f;
    public float low_Sound_Pitch, normal_Sound_Pitch, high_Sound_Pitch;

    // Controls the ausio of the tank and determines if it is slow or not
    public AudioClip engine_On_Sound, engine_Off_Sound;
    private bool is_Slow;

    // A variable that can be accesed in the child class the max amout we and rotate and the speed in which we can rotate
    protected float rotationSpeed = 10f;
    protected float maxAngle = 10f;

    private AudioSource soundManager;

    protected void Awake()
    {
        // Tank starts moving as soon as the game begins
        speed = new Vector3 (0f, 0f, z_Speed);
        soundManager = GetComponent<AudioSource>();
    }

    protected void MoveLeft()
    {
        // Allows the tank to move left
        speed = new Vector3(-x_Speed / 2f, 0f, speed.z);
    }

    protected void MoveRight()
    {
        // Allows the tank to move right
        speed = new Vector3(x_Speed / 2f, 0f, speed.z);
    }

    protected void MoveStraight()
    {
        // Allows the tank to move forward
        speed = new Vector3(0f, 0f, speed.z);
    }

    protected void MoveNormal()
    {
        if(is_Slow)
        {
            is_Slow = false;
            soundManager.Stop();
            soundManager.clip = engine_On_Sound;
            soundManager.volume = 0.3f;
            soundManager.Play();
        }
        speed = new Vector3(speed.x, 0f, z_Speed);
    }

    protected void MoveSlow()
    {
        if (!is_Slow)
        {
            is_Slow = true;
            soundManager.Stop();
            soundManager.clip = engine_Off_Sound;
            soundManager.volume = 0.5f;
            soundManager.Play();
        }
        speed = new Vector3(speed.x, 0f, deccelerated);
    }

    protected void MoveFast()
    {
        speed = new Vector3(speed.x, 0f, accelerated);
    }
}
