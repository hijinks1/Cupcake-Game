using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider slider;
    public float rightValue = 5f; // The target value for a successful completion
    public float leftValue = 0f;
    
    public bool isMoving = false;
    public int successfulAttempts = 0; // Count of successful movements
    public const int winCondition = 5; // Number of successful movements required to win

    public bool canReachTarget = true;

    void Start()
    {
        slider.value = 2.5f; // Start slider in the middle
        slider.onValueChanged.AddListener(OnSliderValueChanged);
        canReachTarget = true;
        Debug.Log("canreachTarget = true");
    }

    void Update()
    {
        if (isMoving)
        {
            if (slider.value == rightValue && canReachTarget)
            {
                successfulAttempts++;
                Debug.Log("Success! Attempts: " + successfulAttempts);
                Debug.Log("canreachTarget = false");
                canReachTarget = false;
                
                if (successfulAttempts >= winCondition)
                {
                    Debug.Log("Next minigame");
           
                    successfulAttempts = 0;
                }
            }

            if (slider.value == leftValue && !canReachTarget)
            {
                Debug.Log("canreachTarget = true");
                canReachTarget = true;
            }
        }
    }

    public void OnSliderValueChanged(float value)
    {
        if (!isMoving)
        {
            isMoving = true; 
        }
    }
}
