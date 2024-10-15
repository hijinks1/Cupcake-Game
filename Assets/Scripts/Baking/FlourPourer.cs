using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlourPourer : MonoBehaviour
{
    public GameObject flour;
    public Animator flourAnimator;
    public int flourPours = 0;
    public int neededPours = 2;
    
    public BakingUI bakingUI;
    public bool movedToNext = false;
    
    public void Start()
    { 
        flourAnimator = flour.GetComponent<Animator>();
        bakingUI = FindObjectOfType<BakingUI>();
    }

    public void Update()
    {
        if (flourPours >= neededPours && !movedToNext)
        {
            movedToNext = true;
            Debug.Log("Move onto egg minigame");
            bakingUI.FinishMinigame(); //Next minigame
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
