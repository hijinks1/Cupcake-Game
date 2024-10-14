using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timertext;
    public int timer = 60;
     void Update()
     {
         timertext.text = timer.ToString();
         Debug.Log(timer);
     }

     private void Start()
     {
         StartCoroutine(CupcakeTimer());
     }

     public IEnumerator CupcakeTimer()
     {
         while (timer > 0)
         {
             timer -= 1;
             yield return new WaitForSeconds(1);
         }

         timertext.text = "Done!";
     }

}
