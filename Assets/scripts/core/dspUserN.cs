using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dspUserN : MonoBehaviour
{
    public TextMeshProUGUI displayplayerUser;

    private void Awake()
    {
        displayplayerUser.text = InputField.inputfield.theName;
    }
}
