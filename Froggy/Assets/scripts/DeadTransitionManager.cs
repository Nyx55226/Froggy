using System;
using System.Collections;
using Microsoft.Win32.SafeHandles;
using UnityEngine;

public class DeadTransitionManager : MonoBehaviour
{
    private Animator an;
    public static DeadTransitionManager Instance;
    [SerializeField] private Canvas UI;

    private void Awake()
    {
        an = GetComponent<Animator>();
        Instance = this;
    }

    public void StartDeadanimation()
    {
        StartCoroutine(animation());
    }

    IEnumerator animation()
    {
        an.SetTrigger("triggerDead");

        yield return new WaitForSeconds(2);
        
        UI.gameObject.SetActive(true);
    }
    
}
