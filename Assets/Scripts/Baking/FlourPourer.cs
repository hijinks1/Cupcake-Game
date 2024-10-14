using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlourPourer : MonoBehaviour
{
    public GameObject flour;
    public Animator flourAnimator;
    public int flourPours;
    public int neededPours = 2;
    
    public void Start()
    { 
        flourAnimator = flour.GetComponent<Animator>();
    }

    public void Update()
    {
        if (flourPours >= neededPours)
        {
            //Debug.Log("Next minigame");
            StopCoroutine(PourFlour());
        }
    }

    public void PlayFlourPour()
    {
        StartCoroutine(PourFlour());
    }

    public IEnumerator PourFlour()
    {
        flourAnimator.Play("PourFlour");
        flourPours++;
        Debug.Log(flourPours);
        yield return new WaitForSeconds(1f);
    }


}
