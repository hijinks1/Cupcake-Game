using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class NextButton : MonoBehaviour
{
    public GameObject[] buttons;
    public int currentIndex = 0;
    public Button nextButton;
    public TextMeshProUGUI buttonText;

    public Timer timer;

    public bool[] buttonClicked;
    void Start()
    {
        UpdateObjectVisibility();
        UpdateButtonState();
        buttonClicked = new bool[buttons.Length];
        buttonText.text = "Next";
    }

    public void OnButtonClicked(int index)
    {
        if (index < buttons.Length)
        {
            buttons[index].SetActive(true);
            buttonClicked[index] = true;
            UpdateButtonState();   
        }
        
        //if currentIndex is 3, change Next text into Done
        if (index == 3)
        {
            buttonText.text = "Done";
            // Do confetti and stop timer!
        }
    }
    
    public void OnNextButtonClicked()
    {
        if (currentIndex < buttonClicked.Length && buttonClicked[currentIndex]) //&& currentIndex < 3)
        {
            if (currentIndex == 3)
            {
                PauseTimer(); 
            }
            buttons[currentIndex].SetActive(false);
            currentIndex++;

            if (currentIndex < buttons.Length)
            {
                UpdateObjectVisibility();
            }
            UpdateButtonState();
        }
    }

    public void UpdateObjectVisibility()
    {
        buttons[currentIndex].SetActive(true);
    }

    public void UpdateButtonState()
    {
        nextButton.interactable = currentIndex < buttonClicked.Length && buttonClicked[currentIndex];// && currentIndex < 3;
    }
    
    private void PauseTimer()
    {
        Timer timer = FindObjectOfType<Timer>();
        if (timer != null)
        {
            timer.Pause(); // Call the Pause method on the Timer instance
        }
    }
}
