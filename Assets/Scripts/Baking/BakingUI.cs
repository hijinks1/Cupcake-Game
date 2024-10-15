using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BakingUI : MonoBehaviour
{
    public List<GameObject> games;
    public int minigameIndex;
    
    private void Start()
    {
        UpdateMinigameVisibility();
    }

    public void UpdateMinigameVisibility()
    {
        foreach (var game in games)
        {
            game.SetActive(false);
        }

        if (minigameIndex < games.Count)
        {
            games[minigameIndex].SetActive(true);
        }
    }

    public void FinishMinigame()
    {
        minigameIndex++;

        if (minigameIndex >= games.Count)
        {
            SceneManager.LoadScene("Cupcake");
        }
        UpdateMinigameVisibility();
    }
}
