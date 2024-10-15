using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public List<Slider> sliders;
    public float rightValue = 5f; // The target value for a successful completion
    public float leftValue = 0f;
    
    public bool isMoving = false;
    public int successfulAttempts = 0; // Count of successful movements
    public const int winCondition = 5; // Number of successful movements required to win

    public bool[] canReachTarget;
    //public bool canReachTarget = true;

    public BakingUI bakingUI;

    void Start()
    {
        canReachTarget = new bool[sliders.Count];
        
        foreach (var slider in sliders)
        {
            slider.value = 2.5f; // Start slider in the middle
            slider.onValueChanged.AddListener(OnSliderValueChanged);
        }
        //canReachTarget = true;
        Debug.Log("canreachTarget = true");
        bakingUI = FindObjectOfType<BakingUI>();
    }

    void Update()
    {
        //foreach (var slider in sliders)
        {
            for (int i = 0; i < sliders.Count; i++)
            {
                Slider slider = sliders[i];
                
                if (slider.value == rightValue && canReachTarget[i])
                {
                    successfulAttempts++;
                    Debug.Log("Success! Attempts: " + successfulAttempts);
                    Debug.Log("canreachTarget = false");
                    canReachTarget[i] = false;
                    //canReachTarget = false;

                    if (successfulAttempts >= winCondition)
                    {
                        Debug.Log("Move to flour minigame");
                        bakingUI.FinishMinigame(); //Next minigame
                        successfulAttempts = 0;
                    }
                }

                if (slider.value == leftValue && !canReachTarget[i])
                {
                    Debug.Log("canreachTarget = true");
                    canReachTarget[i] = true;
                }
            }
        }
    }
    
    public void OnSliderValueChanged(float value)
    {
        for (int i = 0; i < sliders.Count; i++)
        {
            if (sliders[i].value == value)
            {
                if (successfulAttempts < winCondition)
                {
                    canReachTarget[i] = true;
                }

                break;
            }
        }
    }
    
}
