using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public GameObject MainMenuUI;
    public GameObject DropInUI;

    public GameObject Tukano;
    public GameObject Wakapapa;
    public GameObject Torua;
    public GameObject Ngauruho;

    public GameObject PlayerCamera;
    public GameObject Player;

    public GameObject MenuCam;
    
    public GameObject MMCanvas;
    public GameObject PauseCanvas;

     
    public void DropIn()
    {
        DropInUI.SetActive(true);
        MainMenuUI.SetActive(false);      

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Character()
    {
        
    }

    public void DropInBack()
    {
        DropInUI.SetActive(false);
        MainMenuUI.SetActive(true);     

    }


        public void TukanoDrop()
    {
        MenuCam.SetActive(false);
        MMCanvas.SetActive(false);
        PauseCanvas.SetActive(true);
        PlayerCamera.SetActive(true);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Player.transform.position = Tukano.transform.position;
        DropInUI.SetActive(false);
    }

        public void ToruaDrop()
    {
        MenuCam.SetActive(false);
        MMCanvas.SetActive(false);
        PauseCanvas.SetActive(true);
        PlayerCamera.SetActive(true);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Player.transform.position = Torua.transform.position;
        DropInUI.SetActive(false);
    }

        public void NgauruhoDrop()
    {
        MenuCam.SetActive(false);
        MMCanvas.SetActive(false);
        PauseCanvas.SetActive(true);
        PlayerCamera.SetActive(true);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Player.transform.position = Ngauruho.transform.position;
        DropInUI.SetActive(false);
    }

        public void WakapapaDrop()
    {
        MenuCam.SetActive(false);
        MMCanvas.SetActive(false);
        PauseCanvas.SetActive(true);
        PlayerCamera.SetActive(true);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Player.transform.position = Wakapapa.transform.position;
        DropInUI.SetActive(false);
    }

}
