using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EggCracker : MonoBehaviour
{
    public GameObject egg;
    public Animator eggAnimator;
    public int eggCracks = 0;
    public int neededCracks = 2;
    
    public BakingUI bakingUI;
    public bool movedToNext = false;
    
    public void Start()
    { 
        eggAnimator = egg.GetComponent<Animator>();
        bakingUI = FindObjectOfType<BakingUI>();
    }

    public void Update()
    {
        if (eggCracks >= neededCracks && !movedToNext)
        {
            movedToNext = true;
            Debug.Log("move to mixer minigame");
            bakingUI.FinishMinigame(); //Next minigame
            StopCoroutine(CrackEgg());
        }
    }

    public void PlayEggCrack()
    {
        StartCoroutine(CrackEgg());
    }

    public IEnumerator CrackEgg()
    {
        eggAnimator.Play("Crack");
        eggCracks++;
        Debug.Log(eggCracks);
        yield return new WaitForSeconds(1f);
    }
}
