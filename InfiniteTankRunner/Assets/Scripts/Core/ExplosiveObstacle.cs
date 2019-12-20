using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveObstacle : MonoBehaviour
{
    public GameObject explosionPrefab;
    public int damage = 20;

    void OnCollisionEnter(Collision target) 
    {
        // Make the game object dissaper when player touches it
        if (target.gameObject.tag == "Player")
        {
            Instantiate (explosionPrefab, transform.position, Quaternion.identity);
            
            target.gameObject.GetComponent<PlayerHealth>().ApplyDamage(damage);
            gameObject.SetActive(false);
        }

        if (target.gameObject.tag == "Bullet")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }



    }
}
