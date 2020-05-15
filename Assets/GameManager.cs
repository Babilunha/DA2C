using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject pauseMenu;

    public static bool gameIsPaused;

    // Start is called before the first frame update
    void Start()
    {
        gameIsPaused = false;
        RemoveCursor();
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EscActive();
        }
    }

    void EscActive()
    {
        if (gameIsPaused == true)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    void RemoveCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void ActivateCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Resume()
    {
        RemoveCursor();
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        gameIsPaused = false;
    }

    void Pause()
    {
        ActivateCursor();
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        gameIsPaused = true;
    }
}
