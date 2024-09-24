using System.Net.NetworkInformation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Menu : MonoBehaviour
{

    public GameObject menu;
    public GameObject settings;
    public KeyCode pauseKey = KeyCode.Escape;


    void Awake()
    {
      
    }

    public void PauseGame()
    {
        Debug.Log("PauseGame");
        if (menu != null && menu.activeSelf)
        {
            ResumeGame();
        }
        else if (menu != null)
        {
            menu.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            AudioListener.volume = 0;
        }
    }

    public void ResumeGame()
    {
        AudioListener.volume = 1;
        menu.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        settings.SetActive(false);
    }

    public void OpenSettings()
    {
        settings.SetActive(true);
        menu.SetActive(false);
    }

    public void OpenMenu()
    {
        menu.SetActive(true);
        settings.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu_Scene");
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            PauseGame();
        }
    }
}
