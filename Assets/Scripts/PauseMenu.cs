using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    public static bool GameIsPaused = false;

    public GameObject PauseMenuUI;
    public GameObject DropInMenuUI;
    public GameObject MainMenuUI;
    public GameObject MMDropInUI;

    public GameObject Tukano;
    public GameObject Wakapapa;
    public GameObject Torua;
    public GameObject Ngauruho;

    public GameObject PlayerCamera;
    public Rigidbody Player;

    public GameObject MenuCam;

    public GameObject MainMenuCanvas;
    public GameObject PauseMenuCanvas;


    
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
                Cursor.visible = true;
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
        Cursor.visible = true;
    }



    public void DropIn()
    {
        DropInMenuUI.SetActive(true);
        PauseMenuUI.SetActive(false);
    }

    public void DropInBack()
    {
        DropInMenuUI.SetActive(false);
        PauseMenuUI.SetActive(true);
    }

    public void BailOut()
    {
        PauseMenuCanvas.SetActive(false);
        MainMenuCanvas.SetActive(true);
        MainMenuUI.SetActive(true);
        MMDropInUI.SetActive(false);
        PlayerCamera.SetActive(false);
        MenuCam.SetActive(true);
        Cursor.visible = true;
        
    }

    
    
    
    public void TukanoDrop()
    {
        Player.transform.position = Tukano.transform.position;
        DropInMenuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

        public void ToruaDrop()
    {
        Player.transform.position = Torua.transform.position;
        DropInMenuUI.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

        public void NgauruhoDrop()
    {
        Player.transform.position = Ngauruho.transform.position;
        DropInMenuUI.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

        public void WakapapaDrop()
    {
        Player.transform.position = Wakapapa.transform.position;
        DropInMenuUI.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    
}
