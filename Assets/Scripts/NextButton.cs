using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextButton : MonoBehaviour
{
    public GameObject[] buttons;
    public int currentIndex = 0;
    public Button nextButton;

    public bool[] buttonClicked;
    void Start()
    {
        UpdateObjectVisibility();
        UpdateButtonState();
        buttonClicked = new bool[buttons.Length];
    }

    public void OnButtonClicked(int index)
    {
        if (index < buttons.Length)
        {
            buttons[index].SetActive(true);
            buttonClicked[index] = true;
            UpdateButtonState();   
        }
    }
    
    public void OnNextButtonClicked()
    {
        if (currentIndex < buttonClicked.Length && buttonClicked[currentIndex] && currentIndex < 3)
        {
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
        nextButton.interactable = currentIndex < buttonClicked.Length && buttonClicked[currentIndex] && currentIndex < 3;
    }
    
}
