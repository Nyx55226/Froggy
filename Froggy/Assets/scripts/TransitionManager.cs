using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TransitionManager : MonoBehaviour
{
    private Animator an;

    public static TransitionManager instance; 

    private void Awake()
    {
        an = GetComponent<Animator>();
        instance = this;
    }

    public void loadNextLevel()
    {
        StartCoroutine(loadScene());
    }

    IEnumerator loadScene()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 >= SceneManager.sceneCountInBuildSettings)
        {
            an.SetTrigger("triggerTransitition");
            
            yield return new WaitForSeconds(1);
            
            PlayerPrefs.DeleteKey("LevelCount");
            PlayerPrefs.Save();
            
            SceneManager.LoadScene(0);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            yield break;
        }
        an.SetTrigger("triggerTransitition");
        
        PlayerPrefs.SetInt("LevelCount",SceneManager.GetActiveScene().buildIndex+1);
        PlayerPrefs.Save();

        yield return new WaitForSeconds(1);
        
        SceneManager.LoadScene(PlayerPrefs.GetInt("LevelCount"));
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
