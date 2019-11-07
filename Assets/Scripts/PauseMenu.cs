using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    public static bool GameIsPaused = false;

    public GameObject PauseMenuUI;
    public GameObject DropInMenuUI;

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            } else 
            {
                Pause();
            }
        }
        
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

        Cursor.lockState = CursorLockMode.None;
    }

    public void DropIn()
    {
        DropInMenuUI.SetActive(true);
        PauseMenuUI.SetActive(false);
    }

    public void DropInBack()
    {
        Debug.Log("test");
        DropInMenuUI.SetActive(false);
        PauseMenuUI.SetActive(true);
    }

    public void BailOut()
    {
        SceneManager.LoadScene("MainMenu");
    }

    
}
