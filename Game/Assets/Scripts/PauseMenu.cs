using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GamePaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
                Cursor.visible = false;
            }
            else
            {
                Pause();
                Cursor.visible = true;
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1.0f;
        GamePaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Cursor.visible = true;
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void EndGame()
    {
        Application.Quit();
    }
}