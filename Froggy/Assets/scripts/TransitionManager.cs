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
            
            PlayerPrefs.SetInt("LevelCount",1);
            
            SceneManager.LoadScene(0);
            StopAllCoroutines();
        }
        an.SetTrigger("triggerTransitition");
        
        PlayerPrefs.SetInt("LevelCount",SceneManager.GetActiveScene().buildIndex+1);

        yield return new WaitForSeconds(1);
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
