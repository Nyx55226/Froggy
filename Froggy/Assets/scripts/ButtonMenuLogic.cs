using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonMenuLogic : MonoBehaviour
{
    [SerializeField] [CanBeNull] private Button btnContinue;
    private void Start()
    {
        if (!PlayerPrefs.HasKey("LevelCount") && btnContinue)
            btnContinue.interactable = false;
        
    }

    public void quitBtn()
    {
        Application.Quit();
    }

    public void ContinueGame()
    {
        GameManager.instance.loadLevel();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ReturnToHome()
    {
        SceneManager.LoadScene(0);
    }

    public void newGame()
    {
        PlayerPrefs.DeleteKey("LevelCount");
        PlayerPrefs.Save();
        GameManager.instance.loadLevel();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    
}
