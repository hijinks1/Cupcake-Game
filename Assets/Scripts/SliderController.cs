using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SliderController : MonoBehaviour
{
    public Slider slider;
    public float rightValue = 5f; // The target value for a successful completion
    public float leftValue = 0f;
    
    public float tolerance = 0.1f; // Acceptable range around the target value
    public float successThreshold = 60.0f; // Time allowed for successful movement
    public float timer = 0f;
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
            timer += Time.deltaTime;

            if (slider.value == rightValue && canReachTarget)
            {
                successfulAttempts++;
                Debug.Log("Success! Attempts: " + successfulAttempts);
                Debug.Log("canreachTarget = false");
                canReachTarget = false;
                
                if (successfulAttempts >= winCondition)
                {
                    Debug.Log("You win!");
                    ResetGame();
                    //Win screen
                }
            }

            if (slider.value == leftValue && !canReachTarget)
            {
                Debug.Log("canreachTarget = true");
                canReachTarget = true;
            }
            
            //if the timer gets past the set time limit, you lose
            else if (timer > successThreshold)
            {
                Debug.Log("Failed! Attempts: " + successfulAttempts);
                ResetSlider();
            }
        }
    }

    public void OnSliderValueChanged(float value)
    {
        if (!isMoving)
        {
            isMoving = true; // Start the timer when the slider is first moved
            timer = 0f;
        }
    }

    public void ResetSlider()
    {
        isMoving = false;
        timer = 0f;
        slider.value = 2.5f; // Reset the slider to the middle position
    }

    public void ResetGame()
    {
        successfulAttempts = 0; // Reset attempts for a new game
        ResetSlider(); // Reset slider
        canReachTarget = true;
    }
}
