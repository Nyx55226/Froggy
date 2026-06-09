using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int IndexLevel;
    private void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 60;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void loadLevel()
    {
        IndexLevel=PlayerPrefs.GetInt("LevelCount",1);
        SceneManager.LoadSceneAsync(IndexLevel);
    }
}
