using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saved : MonoBehaviour
{
    SavePlayer playerposData;

    void Start()
    {
        playerposData = FindObjectOfType<SavePlayer>();  
    }

    public void savedGame()
    {
        playerposData.PlayerPosSave();
    }
}
