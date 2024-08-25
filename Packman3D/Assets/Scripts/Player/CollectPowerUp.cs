using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPowerUp : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private PlayerController pc;
    [SerializeField] private GameObject gameManager;
    private GameManager gm;
    [SerializeField] private AudioSource playerAudio;
    [SerializeField] private AudioClip powerUpClip;
    private void Start()
    {
        pc = GetComponent<PlayerController>();
        gm = gameManager.GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            StartCoroutine(pc.PowerUpTimer());
            gm.EatBigCoin();
            playerAudio.PlayOneShot(powerUpClip);
            Destroy(other.gameObject);
        }
    }
}
