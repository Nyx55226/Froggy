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
        }
        else
        {
            Destroy(gameObject);
        }
        IndexLevel=PlayerPrefs.GetInt("LevelCount",1);
    }
    

    public void loadLevel()
    {
        SceneManager.LoadSceneAsync(IndexLevel);
    }
}
