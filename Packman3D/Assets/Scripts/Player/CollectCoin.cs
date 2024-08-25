using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : PlayerController
{
    [SerializeField] private AudioSource playerAudio;
    [SerializeField] private AudioClip pickUpCLip;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            gm.EatCoins();
            playerAudio.PlayOneShot(pickUpCLip);
            Destroy(other.gameObject);
        }
    }
}
