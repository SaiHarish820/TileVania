using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] AudioClip coinSFX;
    [SerializeField] int pointsForCoinPickup = 100;


    bool coinCollected = false;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !coinCollected)
        {
            coinCollected = true;
            FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickup);
            AudioSource.PlayClipAtPoint(coinSFX, Camera.main.transform.position);
            gameObject.SetActive(false);
            Destroy(gameObject);          
        }
    }
}
