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

    public void Start()
    { 
        eggAnimator = egg.GetComponent<Animator>();
    }

    public void Update()
    {
        if (eggCracks >= neededCracks)
        {
            //Debug.Log("Next minigame");
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
