using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using SaveSystem;
using TMPro;

public class PauseMenuHandler : MonoBehaviour
{

    public GameObject settingsMenuPanel;
    public GameObject pauseMenuPanel;

    [SerializeField] private GameObject pauseMenuBackground;
    [SerializeField] private TextMeshProUGUI menuText;
    [SerializeField] private TextMeshProUGUI exitText;

    void Awake()
    {
        Time.timeScale = 1;
        #region NotNullChecks
        if (pauseMenuBackground == null)
        {
            Debug.LogError("pauseMenuBackground not set.");
        }
    }

    void ResumeGame()
    {
        pauseMenuBackground.SetActive(false);
    }

    void RestartGame()
    {
        GameManager.instance.StartNewGame();
    }

    void OpenSettingsMenu()
    {
        GameManager.instance.ShowSettingsMenu();
    }

    void ReturnToMainMenu()
    {
        GameManager.instance.Lad
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex > 1)
        {
            if (pauseMenuPanel.activeSelf)
            {
                Time.timeScale = 1;
                pauseMenuPanel.SetActive(false);
            }
            else if (settingsMenuPanel.activeSelf) Settings();
            else
            {
                Time.timeScale = 0;
                if (SceneManager.GetActiveScene().name == "UpgradeMenuScene")
                {
                    menuText.text = "Save and Return to Menu";
                    exitText.text = "Save and Exit";
                }
                else
                {
                    menuText.text = "Return to Menu";
                    exitText.text = "Exit";
                }
                pauseMenuPanel.SetActive(true);
            }
        }
    }

    public void NewGame()
    {
        Time.timeScale = 1;
        pauseMenuPanel.SetActive(false);
        GameManager.instance.StartNewGame();
    }

    public void Settings()
    {
        if (!settingsMenuPanel.activeSelf)
        {
            settingsMenuPanel.SetActive(true);
            pauseMenuPanel.SetActive(false);
        }
        else
        {
            settingsMenuPanel.SetActive(false);
            pauseMenuPanel.SetActive(true);
        }
    }
    
    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenuPanel.SetActive(false);
    }

    public void ExitGame()
    {
        Time.timeScale = 1;
        if (SceneManager.GetActiveScene().name == "UpgradeMenuScene") SaveSystem.DataManager.instance.UpdateAndSaveToFile();
        Application.Quit();
    }

    public void BackToMain()
    {
        Time.timeScale = 1;
        if (SceneManager.GetActiveScene().name == "UpgradeMenuScene") SaveSystem.DataManager.instance.UpdateAndSaveToFile();
        pauseMenuPanel.SetActive(false);
        SceneManager.LoadScene("MainMenuScene");
    }
}
