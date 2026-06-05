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
        an.SetTrigger("triggerTransitition");

        yield return new WaitForSeconds(1);
        
        SceneManager.LoadScene(0);
    }
}
