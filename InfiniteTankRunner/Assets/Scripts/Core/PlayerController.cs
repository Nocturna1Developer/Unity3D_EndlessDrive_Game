// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// // This script inherits from the base crontroller
// public class PlayerController : BaseController
// {
//     private Rigidbody myBody;
//     public Transform bullet_StartPoint;
//     public GameObject bullet_Prefab;
//     public ParticleSystem shootFX;

//     private Animator shootSliderAnim;

//     [HideInInspector]
//     public bool canShoot;

//     void Start()
//     {
//         myBody = GetComponent<Rigidbody>();
//         // Addlistener executes the funtion when the button is clicked
//         shootSliderAnim = GameObject.Find("FireBar").GetComponent<Animator>();
//         GameObject.Find("ShootButton").GetComponent<Button>().onClick.AddListener(ShootingControl);
//     }

//     void Update()
//     {
//         ChangeRotation();
//         ControlMovementWithKeyboard();
//     }

//     // Constantly moves the tank
//     void FixedUpdate()
//     {
//         MoveTank();
//     }

//     void MoveTank()
//     {
//         // Moves the rigid body to position and adds the speed (from base controller) to the current rigid body
//         myBody.MovePosition(myBody.position + speed * Time.deltaTime);
//     }

//     void ControlMovementWithKeyboard()
//     {
//         if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) )
//         {
//             // This protected fuction was inherited from the base controller class
//             MoveLeft();
//         }

//         if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
//         {
//             MoveRight();
//         }

//         if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
//         {
//             MoveFast();
//         }

//         if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
//         {
//             MoveSlow();
//         }

//         // If the left or right key is released then the tank moves straight
//         if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
//         {
//             MoveStraight();
//         }

//         if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
//         {
//             MoveStraight();
//         }

//         // Moves the tank to a normal speed 
//         if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
//         {
//             MoveNormal();
//         }

//         if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
//         {
//             MoveNormal();
//         }
//     }
//     // makes the player rotate from transform.rotation to max angle in a sphere or 360 degrees in a certian time ( time. delta time)
//     void ChangeRotation()
//     {
//         if (speed.x > 0)
//         {
//             transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, maxAngle, 0f), Time.deltaTime * rotationSpeed);
//         }

//         if (speed.x < 0)
//         {
//             transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, -maxAngle, 0f), Time.deltaTime * rotationSpeed);
//         }
//     }

//     public void ShootingControl()
//     {
//         // As long as the game is not paused the tank tank shoot with the button
//         if(Time.timeScale != 0)
//         {
//             if(canShoot)
//             {
//                 GameObject bullet = Instantiate(bullet_Prefab, bullet_StartPoint.position, Quaternion.identity);
//                 bullet.GetComponent<BulletScript>().Move(2000f);
//                 shootFX.Play();

//                 canShoot = false;
//                 shootSliderAnim.Play("Fill");
//             }  
//         }
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : BaseController
{

    private Rigidbody myBody;

    public Transform bullet_StartPoint;
    public GameObject bullet_Prefab;
    public ParticleSystem shootFX;

    private Animator shootSliderAnim;

    [HideInInspector]
    public bool canShoot;

    void Start()
    {
        myBody = GetComponent<Rigidbody>();

        shootSliderAnim = GameObject.Find("FireBar").GetComponent<Animator>();

        GameObject.Find("ShootButton").GetComponent<Button>().onClick.AddListener(ShootingControl);
        canShoot = true;

    }

    void Update()
    {
        ControlMovementWithKeyboard();
        ChangeRotation();
    }

    void FixedUpdate()
    {
        MoveTank();
    }

    void MoveTank()
    {
        myBody.MovePosition(myBody.position + speed * Time.deltaTime);
    }

    void ControlMovementWithKeyboard()
    {

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            MoveFast();
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            MoveSlow();
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            MoveStraight();
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            MoveStraight();
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
            MoveNormal();
        }

        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            MoveNormal();
        }
    }

    void ChangeRotation()
    {
        if (speed.x > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.Euler(0f, maxAngle, 0f), Time.deltaTime * rotationSpeed);

        }
        else if (speed.x < 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.Euler(0f, -maxAngle, 0f), Time.deltaTime * rotationSpeed);

        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.Euler(0f, 0f, 0f), Time.deltaTime * rotationSpeed);
        }
    }

    public void ShootingControl()
    {

        if (Time.timeScale != 0)
        {
            if (canShoot)
            {
                GameObject bullet = Instantiate(bullet_Prefab, bullet_StartPoint.position,
                    Quaternion.identity);
                bullet.GetComponent<BulletScript>().Move(2000f);
                shootFX.Play();


                canShoot = false;
                shootSliderAnim.Play("Fill");
            }
        }

    }

}