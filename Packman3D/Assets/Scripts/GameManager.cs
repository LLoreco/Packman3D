using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] private TextMeshProUGUI scoreTMP;
    private int score;

    [Header("Coins")]
    [SerializeField] private TextMeshProUGUI coinsTMP;
    private int coins;

    private ScoreData scoreData = new ScoreData();
    private void Awake()
    {
        coins = GameObject.FindGameObjectsWithTag("Coin").Length;
    }
    private void Start()
    {
        scoreTMP.text = "Score: " + score.ToString();
        coinsTMP.text = "Coins: " + coins.ToString();
    }
    private void Update()
    {
        coinsTMP.text = "Coins: " + coins.ToString();
        scoreTMP.text = "Score: " + score.ToString();
    }
    public void EatCoins()
    {
        coins--;
        score += scoreData.StandartCoin;
    }
}
