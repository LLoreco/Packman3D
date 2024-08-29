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

    [Header("UI")]
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private TextMeshProUGUI scorePoint;
    [SerializeField] private TextMeshProUGUI winScorePoint;
    private Animator pauseAnimator;
    private Animator gameOverAnimator;
    private Animator winScreenAnimator;
    private bool pauseCalled;

    public bool isGamePaused;

    private bool isGameOver;
    public bool IsGameOver
    {
        get
        {
            return isGameOver;
        }
    }

    private ScoreData scoreData = new ScoreData();
    private void Awake()
    {
        coins = GameObject.FindGameObjectsWithTag("Coin").Length;
    }
    private void Start()
    {
        scoreTMP.text = "Score: " + score.ToString();
        coinsTMP.text = "Coins: " + coins.ToString();
        isGameOver = false;
        pauseCalled = false;
    }
    private void Update()
    {
        coinsTMP.text = "Coins: " + coins.ToString();
        scoreTMP.text = "Score: " + score.ToString();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CallPause();
        }
       
    }
    public void EatCoins()
    {
        coins--;
        score += scoreData.StandartCoin;
        if (coins == 0)
        {
            ShowWinScreen();
        }
    }
    public void EatBigCoin()
    {
        score += scoreData.BigCoin;
    }
    public void KillGhost()
    {
        score += scoreData.EatGhost;
    }
    public void GameOver()
    {
        isGameOver = true;
        gameOverAnimator = gameOverScreen.GetComponent<Animator>();
        gameOverAnimator.SetBool("GameOver", true);
        scorePoint.text = score.ToString();
    }
    public void CallPause()
    {
        pauseCalled = !pauseCalled;
        if (pauseCalled)
        {
            pauseAnimator = pauseMenu.GetComponent<Animator>();
            pauseAnimator.SetBool("OpenPauseMenu", true);
            StartCoroutine(PauseMenuAnimationPlay(0));
        }
        else
        {
            StartCoroutine(PauseMenuAnimationPlay(1));
            pauseAnimator.SetBool("OpenPauseMenu", false);
        }
    }
    IEnumerator PauseMenuAnimationPlay(int time)
    {
        if (time == 1)
        {
            Time.timeScale = time;
        }
        else
        {
            yield return new WaitForSeconds(2);
            Time.timeScale = time;
        }
    }
    private void ShowWinScreen()
    {
        winScreenAnimator = winScreen.GetComponent<Animator>();
        winScreenAnimator.SetBool("Win", true);
        DestroyGhosts();
    }
    private void DestroyGhosts()
    {
        GameObject[] ghosts = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < ghosts.Length; i++)
        {
            Destroy(ghosts[i]);
        }
    }
}
