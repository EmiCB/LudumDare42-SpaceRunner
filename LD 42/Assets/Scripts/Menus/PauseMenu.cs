using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    public BoundaryController bc;

    public string mainMenuLevel;

    public GameObject pauseMenu;

    public void Start()
    {
        bc = FindObjectOfType<BoundaryController>();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;    //freeze time
        bc.isMovingBoundaries = false;
        pauseMenu.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        bc.isMovingBoundaries = true;
        pauseMenu.SetActive(false);
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        FindObjectOfType<GameController>().Reset();
    }
    public void QuitToMain()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        SceneManager.LoadScene(mainMenuLevel);
    }
}
