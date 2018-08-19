using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public string playGameLevel;

    public GameObject controls;
    public GameObject exitControls;
    public GameObject title;
    public GameObject playButton;
    public GameObject controlsButton;
    public GameObject exitButton;


    void Start()
    {
        controls.SetActive(false);
        exitControls.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(playGameLevel);
    }
    public void DisplayControls()
    {
        controls.SetActive(true);
        exitControls.SetActive(true);
        title.SetActive(false);
        playButton.SetActive(false);
        controlsButton.SetActive(false);
        exitButton.SetActive(false);

    }
    public void ExitControls()
    {
        controls.SetActive(false);
        exitControls.SetActive(false);
        title.SetActive(true);
        playButton.SetActive(true);
        controlsButton.SetActive(true);
        exitButton.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
