using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class InputField : MonoBehaviour
{
    public static InputField inputfield;
    public TMP_InputField inputtext;

    public string theName;

    private void Awake()   // singleton method
    {
        if(inputfield == null)
        {
            inputfield = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void StoreName()
    {
        theName = inputtext.text;
    }
}
