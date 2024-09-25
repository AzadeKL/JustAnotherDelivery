using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string StartingSceneName = "InventorySortingScene";
    public GameObject continueButton;
    public GameObject loadMenuPanel;
    public GameObject settingsMenuPanel;

    private GameObject activePanel;
    private bool hasSaveFile = false;

    void Awake()
    {
        #region NotNullChecks
        if (continueButton == null)
        {
            Debug.LogError("Continue Button not found.");
        }

        if (loadMenuPanel == null) {
            Debug.LogError("Load Panel not found.");
        }

        if (settingsMenuPanel == null) {
             Debug.LogError("Settings Panel not found.");
        }
        #endregion

        loadMenuPanel.SetActive(false);
        settingsMenuPanel.SetActive(false);
        HandleContinueButtonStatus();
    }

    public void NewGame()
    {
        SceneManager.LoadScene(StartingSceneName);
    }

    public void ContinueGame()
    {
        //TODO: Continue from last saved file logic
        Debug.Log("You pressed the Continue Game button.");
    }

    public void LoadGame()
    {
        loadMenuPanel.SetActive(true);
        activePanel = loadMenuPanel;
    }

    public void Settings()
    {
        settingsMenuPanel.SetActive(true);
        activePanel = settingsMenuPanel;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void BackToMain()
    {
        activePanel.SetActive(false);
        activePanel = null;
    }

    private void HandleContinueButtonStatus()
    {
        //if save file exists, hasSaveFile = true
        if (hasSaveFile)
        {
            continueButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            continueButton.GetComponent<Button>().interactable = false;
        }
    }
}
