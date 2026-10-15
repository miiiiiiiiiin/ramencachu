using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class inputfield : MonoBehaviour
{
    public TMP_InputField pwInputField;
    void Update() {
        if (pwInputField.isFocused) // password 에 포커스가 되어있을때
        {
            Input.imeCompositionMode = IMECompositionMode.Off;
        }
        else 
        {
            Input.imeCompositionMode = IMECompositionMode.Auto;
        }
    } 
}
