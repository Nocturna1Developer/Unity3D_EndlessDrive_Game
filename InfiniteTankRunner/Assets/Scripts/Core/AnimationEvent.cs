using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AnimationEvent : MonoBehaviour
{
    private PlayerController playerController;
    private Animator anim;

    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
    }
    
    //Makes it so the player cant shoot 1000 bullets at once
    void ResetShooting()
    {
        playerController.canShoot = true;
        anim.Play("Idle");
    }

    //void CameraStartGame()
    //{
    //    SceneManager.LoadScene("Gameplay");
    //}

}