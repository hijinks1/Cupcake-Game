using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EggCracker : MonoBehaviour
{
    public GameObject egg;
    public GameObject eggCrack1;
    public GameObject eggCrack2;
    public Animator eggAnimator;

    public void Start()
    { 
        eggAnimator = egg.GetComponent<Animator>();
    }

    public void PlayEggCrack()
    {
        StartCoroutine(CrackEgg());
    }

    public IEnumerator CrackEgg()
    {
        eggAnimator.Play("Crack");
        yield return new WaitForSeconds(1f);
    }
}
