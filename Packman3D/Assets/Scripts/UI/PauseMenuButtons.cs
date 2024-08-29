using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject GameManager;
    public void ResetLevel()
    {
        GameManager gm = GameManager.GetComponent<GameManager>();
        gm.CallPause();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GoToMainMenu()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Debug.Log("SCENE 0");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
    public void ContinueGame()
    {
        GameManager gm = GameManager.GetComponent<GameManager>();
        gm.CallPause();
    }
}
