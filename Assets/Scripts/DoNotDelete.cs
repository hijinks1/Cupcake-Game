using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoNotDelete : MonoBehaviour
{
    public GameObject text;
    void Awake()
    {
        DontDestroyOnLoad(gameObject); 
    }
}
