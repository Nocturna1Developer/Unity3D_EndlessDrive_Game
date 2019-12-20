using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    public Transform target;

    public float distance;
    public float height;

    public float height_Damping;
    public float rotation_Damping;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Updated in the end of the executon 
    void LateUpdate()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        // Angle of the players y axis
        float wanted_Rotation_Angle = target.eulerAngles.y;
        float wanted_Height = target.position.y + height;

        float current_Rotation_Angle = transform.eulerAngles.y;
        float current_Height = transform.position.y;

        // The time (time.deltatime) it takes to from current_rotation_angle to wanted_rotation_angle linearly
        current_Rotation_Angle = Mathf.LerpAngle(current_Rotation_Angle, wanted_Rotation_Angle, rotation_Damping * Time.deltaTime);
        // The time (time.deltatime) it takes to from current_height to wanted hieght linearly
        current_Height = Mathf.Lerp(current_Height, wanted_Height, height_Damping * Time.deltaTime);
    
        // Converts the current_rotation_angle into a qaternion (represents rotation)
        Quaternion current_Rotation = Quaternion.Euler (0f, current_Rotation_Angle, 0f);

        // Gives us distance from the player
        transform.position = target.position;
        transform.position -= current_Rotation * Vector3.forward * distance;

        transform.position = new Vector3 (transform.position.x, current_Height, transform.position.z);
    }
}
