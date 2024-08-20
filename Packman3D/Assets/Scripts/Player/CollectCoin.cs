using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    [SerializeField] private GameObject gameManager;
    private GameManager gm;
    private void Start()
    {
        gm = gameManager.GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            gm.EatCoins();
            Destroy(other.gameObject);
        }
    }
}
